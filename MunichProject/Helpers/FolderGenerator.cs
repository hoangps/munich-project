using MunichProject.Models;
using System;
using System.Collections.Generic;

namespace MunichProject.Helpers
{
    public class FolderGenerator
    {
        private const int MAX_SUBFOLDERS_IN_FOLDER = 3;
        private const int MAX_FILES_IN_FOLDER = 5;
        private const int MAX_FILE_SIZE_LENGTH = 999999999;
        private const int MAX_FOLDER_LEVEL = 5;

        private int _folderIdentity = 1;
        private int _fileIdentity = 1;

        private Random _random = new Random();

        public int NextFolderIdentity { get { return _folderIdentity++; } }
        public int NextFileIdentity { get { return _fileIdentity++; } }


        public FolderModel GenerateFolder(int level, int? parentId)
        {
            var folderId = NextFolderIdentity;

            return new FolderModel
            {
                Id = folderId,
                ParentId = parentId,
                Name = $"Folder {folderId}",
                Files = GenerateFiles(1),
                Subfolders = level < MAX_FOLDER_LEVEL ? GenerateFolders(level + 1, folderId) : null
            };
        }

        private IEnumerable<FolderModel> GenerateFolders(int level, int? parentId)
        {
            var folderList = new List<FolderModel>();
            for (int i = 0; i < _random.Next(MAX_SUBFOLDERS_IN_FOLDER); i++)
                folderList.Add(GenerateFolder(level, parentId));

            return folderList;
        }

        private IEnumerable<FileModel> GenerateFiles(int folderId)
        {
            var fileList = new List<FileModel>();
            for (int i = 0; i < _random.Next(MAX_FILES_IN_FOLDER); i++)
                fileList.Add(GenerateFile(folderId));

            return fileList;
        }

        private FileModel GenerateFile(int folderId)
        {
            var fileId = NextFileIdentity;

            return new FileModel
            {
                Id = fileId,
                FolderId = folderId,
                Name = $"File {fileId}",
                Size = _random.Next(MAX_FILE_SIZE_LENGTH)
            };
        }
    }
}