using System;
using System.IO;
using System.Reflection;

public class ArchivatorAdapter
{
    private readonly object _archivator;
    private readonly MethodInfo _archiveXmlFileMethod;
    private readonly MethodInfo _unzipArchiveMethod;

    public ArchivatorAdapter(string assemblyPath)
    {
        Assembly pluginAssembly = Assembly.LoadFrom(assemblyPath);
        Type archivatorType = pluginAssembly.GetType("UserArchievePlugin.Archivator");

        if (archivatorType == null)
        {
            throw new Exception("Archivator type not found in the selected assembly.");
        }

        _archivator = Activator.CreateInstance(archivatorType);

        _archiveXmlFileMethod = archivatorType.GetMethod("ArchiveXmlFile");
        _unzipArchiveMethod = archivatorType.GetMethod("UnzipArchive");

        if (_archiveXmlFileMethod == null || _unzipArchiveMethod == null)
        {
            throw new Exception("Methods not found in the selected Archivator type.");
        }
    }

    public void ArchiveXmlFile(string filePath, string zipFilePath)
    {
        _archiveXmlFileMethod.Invoke(_archivator, new object[] { filePath, zipFilePath });
    }

    public void UnzipArchive(string archivePath, string extractPath)
    {
        _unzipArchiveMethod.Invoke(_archivator, new object[] { archivePath, extractPath });
    }
}
