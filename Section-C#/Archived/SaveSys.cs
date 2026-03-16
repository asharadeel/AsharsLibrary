

/*
INCOMPLETE
v0.0.1
*/

class SaveSys
{

    /// <summary>
    /// If file exists, add data to it. If not, create it USING
    /// SaveToNewFile() and add data.
    /// </summary>
    /// <param name="filename"></param>
    /// <param name="content"></param>
    public static void SaveToFile(string filename, string content)
    {
        System.IO.File.WriteAllText(filename, content);
    }

    /// <summary>
    /// Create a new file and write data to it. If file exists, throw error.
    /// </summary>
    public static void SaveToNewFile(string filename, string content)
    {
        if (!System.IO.File.Exists(filename))
        {
            System.IO.File.WriteAllText(filename, content);
        }
        else
        {
            throw new Exception("File already exists.");
        }
    }

    /// <summary>
    /// Read data from a file.
    /// </summary>
    /// <param name="filename"></param>
    public static string ReadFromFile(string filename)
    {
        return System.IO.File.ReadAllText(filename);
    }

    
}