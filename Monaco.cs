HtmlDocument document = webBrowser1.Document;
string scriptName = "GetText";
object[] args = new object[] { };
string text = document.InvokeScript(scriptName, args)?.ToString() ?? "";

using (SaveFileDialog saveFileDialog = new SaveFileDialog())
{
    saveFileDialog.Filter = "Lua Script (*.lua)|*.lua|Text File (*.txt)|*.txt|All Files (*.*)|*.*";
    saveFileDialog.Title = "Save your lua file";
    saveFileDialog.ShowDialog();

    if (!string.IsNullOrEmpty(saveFileDialog.FileName))
    {
        try
        {
            File.WriteAllText(saveFileDialog.FileName, text);
        }
        catch (Exception ex)
        {
            // Handle the exception here or rethrow it
            Console.WriteLine(ex.ToString());
        }
    }
}