namespace CSStudy
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            //先打开登录窗口

            LoginForm login = new LoginForm();
            if (login.ShowDialog() == DialogResult.OK)
            {
                //登录成功，打开主界面Form1
                //Application.Run(new MainForm());
                MainForm main = new MainForm();
                main.LoginUserName = login.LoggedInUserName;

                Application.Run(main);
            }
            //登录失败直接退出程序
        }
    }
}