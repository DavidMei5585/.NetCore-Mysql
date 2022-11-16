using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http.Headers;

using Wytn.Sys.Model.Entity;
using Wytn.Sys.Repository.Interface;
using Wytn.Sys.Service.Interface;

using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace Wytn.Sys.Service
{
    /// <inheritdoc/>
    public class HelperService : IHelperService
    {
        /// <summary>
        /// 操作教學 Repository
        /// </summary>
        private readonly IHelperRepository helperRepository;

        /// <summary>
        /// config 物件
        /// </summary>
        private readonly IConfiguration configuration;

        public HelperService(IHelperRepository helperRepository, IConfiguration configuration)
        {
            this.helperRepository = helperRepository;
            this.configuration = configuration;
        }

        public void delete(string id)
        {
            Helper helper = helperRepository.Query(id);
            if (helper != null)
            {
                FileInfo f = new FileInfo(Path.Combine(helper.filePath, helper.realName));
                if (f != null)
                    f.Delete();
            }
            helperRepository.Delete(id);
        }

        public List<Helper> findAll()
        {
            return helperRepository.QueryAll();
        }

        public byte[] getPdfById(string id)
        {
            byte[] bytes = null;
            Helper helper = helperRepository.Query(id);
            if (helper != null)
                bytes = File.ReadAllBytes(Path.Combine(helper.filePath, helper.realName));
            return bytes;
        }

        public byte[] getPdfByName(string name)
        {
            byte[] bytes = null;
            Helper helper = helperRepository.getByName(name);
            if (helper != null)
                bytes = File.ReadAllBytes(Path.Combine(helper.filePath, helper.realName));
            return bytes;
        }

        public Helper save(string id, string url, IFormFile file)
        {
            string path = configuration["App:HelperPath"];

            string fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            string realName = Guid.NewGuid().ToString() + fileName.Substring(fileName.LastIndexOf('.'));

            using var stream = new FileStream(Path.Combine(path, realName), FileMode.Create);
            file.CopyTo(stream);

            Helper helper = new Helper();
            helper.name = url;
            helper.fileName = fileName;
            helper.filePath = path;
            helper.realName = realName;
            helperRepository.Insert(helper);

            return helper;
        }
    }
}
