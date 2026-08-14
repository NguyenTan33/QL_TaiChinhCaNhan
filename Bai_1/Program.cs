namespace Bai_1
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            
            try
            {
                ImportExcelRunner.RunImport();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Import Excel Note: " + ex.Message);
            }

            Application.Run(new Form1());
        }
    }
}