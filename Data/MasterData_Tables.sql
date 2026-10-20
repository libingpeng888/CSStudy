-- ============================================================
--  CSStudy 基础资料（主数据）建表脚本
--  包含：仓库档案 Warehouse、计量单位 Unit、数据字典 SysDict
--  特点：IF OBJECT_ID 判空，可重复执行（幂等），不会误删已有数据
--  执行：在 TestDB 上运行本脚本即可
-- ============================================================

-- ------------------------------------------------------------
-- 1) 仓库档案 Warehouse
-- ------------------------------------------------------------
IF OBJECT_ID('dbo.Warehouse', 'U') IS NULL
CREATE TABLE dbo.Warehouse
(
    uGUID      uniqueidentifier NOT NULL DEFAULT NEWID() PRIMARY KEY, -- 主键
    wNo        nvarchar(50)     NOT NULL,                            -- 仓库编号
    wName      nvarchar(100)    NOT NULL,                            -- 仓库名称
    wLocation  nvarchar(200)    NULL,                                -- 库位/地址
    wRemark    nvarchar(500)    NULL,                                -- 备注
    CreateUser nvarchar(50)     NULL,
    CreateTime datetime         NULL DEFAULT GETDATE(),
    UpdateUser nvarchar(50)     NULL,
    UpdateTime datetime         NULL
);

-- ------------------------------------------------------------
-- 2) 计量单位 Unit（纺织双单位的基础：米/公斤/码/匹…）
--    uFactor：相对“基准单位”的换算系数（基准单位本身为 1）
--    uBase  ：是否基准单位（同一种换算体系里通常只有一个）
-- ------------------------------------------------------------
IF OBJECT_ID('dbo.Unit', 'U') IS NULL
CREATE TABLE dbo.Unit
(
    uGUID      uniqueidentifier NOT NULL DEFAULT NEWID() PRIMARY KEY, -- 主键
    uNo        nvarchar(50)     NOT NULL,                            -- 单位编码
    uName      nvarchar(50)     NOT NULL,                            -- 单位名称
    uFactor    decimal(18, 4)   NOT NULL DEFAULT 1,                  -- 换算系数
    uBase      bit              NOT NULL DEFAULT 0,                  -- 是否基准单位
    uRemark    nvarchar(500)    NULL,                                -- 备注
    CreateUser nvarchar(50)     NULL,
    CreateTime datetime         NULL DEFAULT GETDATE(),
    UpdateUser nvarchar(50)     NULL,
    UpdateTime datetime         NULL
);

-- ------------------------------------------------------------
-- 3) 数据字典 SysDict（单表多类型：物料分类/部门/性别…都用这张表）
--    新增一种下拉类型只需加行，不用改表、不用改程序
-- ------------------------------------------------------------
IF OBJECT_ID('dbo.SysDict', 'U') IS NULL
CREATE TABLE dbo.SysDict
(
    uGUID      uniqueidentifier NOT NULL DEFAULT NEWID() PRIMARY KEY, -- 主键
    DictType   nvarchar(50)     NOT NULL,                            -- 字典类型
    DictCode   nvarchar(50)     NOT NULL,                            -- 字典编码
    DictName   nvarchar(100)    NOT NULL,                            -- 字典名称（显示值）
    SortOrder  int              NOT NULL DEFAULT 0,                  -- 排序号
    IsEnabled  bit              NOT NULL DEFAULT 1,                  -- 是否启用
    CreateUser nvarchar(50)     NULL,
    CreateTime datetime         NULL DEFAULT GETDATE(),
    UpdateUser nvarchar(50)     NULL,
    UpdateTime datetime         NULL
);

-- ============================================================
--  初始化示例数据（幂等：不存在才插入，重复执行安全）
-- ============================================================

-- 计量单位（以“米”为基准）
INSERT INTO dbo.Unit (uNo, uName, uFactor, uBase, uRemark)
SELECT v.uNo, v.uName, v.uFactor, v.uBase, v.uRemark
FROM (VALUES
    ('M',  N'米',   1.0000, 1, N'长度基准单位'),
    ('KG', N'公斤', 1.0000, 0, N'按重量计（换算系数按实际业务维护）'),
    ('YD', N'码',   0.9144, 0, N'1码=0.9144米'),
    ('PZ', N'匹',   1.0000, 0, N'按匹计')
) AS v(uNo, uName, uFactor, uBase, uRemark)
WHERE NOT EXISTS (SELECT 1 FROM dbo.Unit u WHERE u.uNo = v.uNo);

-- 数据字典：性别
INSERT INTO dbo.SysDict (DictType, DictCode, DictName, SortOrder, IsEnabled)
SELECT v.DictType, v.DictCode, v.DictName, v.SortOrder, v.IsEnabled
FROM (VALUES
    (N'性别', N'1', N'男', 1, 1),
    (N'性别', N'2', N'女', 2, 1)
) AS v(DictType, DictCode, DictName, SortOrder, IsEnabled)
WHERE NOT EXISTS (SELECT 1 FROM dbo.SysDict d WHERE d.DictType = v.DictType AND d.DictCode = v.DictCode);

-- 数据字典：部门
INSERT INTO dbo.SysDict (DictType, DictCode, DictName, SortOrder, IsEnabled)
SELECT v.DictType, v.DictCode, v.DictName, v.SortOrder, v.IsEnabled
FROM (VALUES
    (N'部门', N'D01', N'研发部', 1, 1),
    (N'部门', N'D02', N'市场部', 2, 1),
    (N'部门', N'D03', N'财务部', 3, 1),
    (N'部门', N'D04', N'生产部', 4, 1)
) AS v(DictType, DictCode, DictName, SortOrder, IsEnabled)
WHERE NOT EXISTS (SELECT 1 FROM dbo.SysDict d WHERE d.DictType = v.DictType AND d.DictCode = v.DictCode);

-- 数据字典：物料分类
INSERT INTO dbo.SysDict (DictType, DictCode, DictName, SortOrder, IsEnabled)
SELECT v.DictType, v.DictCode, v.DictName, v.SortOrder, v.IsEnabled
FROM (VALUES
    (N'物料分类', N'C01', N'原材料', 1, 1),
    (N'物料分类', N'C02', N'半成品', 2, 1),
    (N'物料分类', N'C03', N'成品', 3, 1),
    (N'物料分类', N'C04', N'辅料', 4, 1),
    (N'物料分类', N'C05', N'包装物', 5, 1)
) AS v(DictType, DictCode, DictName, SortOrder, IsEnabled)
WHERE NOT EXISTS (SELECT 1 FROM dbo.SysDict d WHERE d.DictType = v.DictType AND d.DictCode = v.DictCode);

-- 数据字典：技能
-- 注意：DictName 必须与 Person.sSkill 里存储的词完全一致（C# / SQL / Delphi），
-- 否则双击回显时 Contains 匹配不上，历史数据会丢勾选
INSERT INTO dbo.SysDict (DictType, DictCode, DictName, SortOrder, IsEnabled)
SELECT v.DictType, v.DictCode, v.DictName, v.SortOrder, v.IsEnabled
FROM (VALUES
    (N'技能', N'SK01', N'C#',     1, 1),
    (N'技能', N'SK02', N'SQL',    2, 1),
    (N'技能', N'SK03', N'Delphi', 3, 1)
) AS v(DictType, DictCode, DictName, SortOrder, IsEnabled)
WHERE NOT EXISTS (SELECT 1 FROM dbo.SysDict d WHERE d.DictType = v.DictType AND d.DictCode = v.DictCode);
