using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using UEditor.Core;

namespace Learn.Web.Controllers
{
    public class ManageController : Controller 
    {
        private IHostingEnvironment hostingEnv;
        private readonly UEditorService _ueditorService;
        public ManageController(IHostingEnvironment env, UEditorService ueditorService)
        { 
            this.hostingEnv = env;
            this._ueditorService = ueditorService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Upload()
        {
            return View();
        }
        public IActionResult Ueditor()
        {
            return View();
        }
        [HttpGet, HttpPost]
        public ContentResult UEUpload()
        {
            var response = _ueditorService.UploadAndGetResponse(HttpContext);
            return Content(response.Result, response.ContentType);
        }

        [HttpPost]
        public IActionResult UploadFile()
        {
            try
            {
                #region 文件上传
                var file = Request.Form.Files[0];
                if (file != null && !string.IsNullOrEmpty(file.FileName))
                {
                    long size = 0;
                    string tempname = "";
                    var filename = ContentDispositionHeaderValue
                                    .Parse(file.ContentDisposition)
                                    .FileName
                                    .Trim('"');
                    var extname = filename.Substring(filename.LastIndexOf("."), filename.Length - filename.LastIndexOf("."));
                    var filename1 = System.Guid.NewGuid().ToString()+ extname;
                    tempname = filename1;
                    //var path = hostingEnv.WebRootPath;
                    var path = hostingEnv.ContentRootPath;
                    string dir = DateTime.Now.ToString("yyyyMMdd");
                    if (!System.IO.Directory.Exists(path + $@"\Upload\UploadFile\{dir}"))
                    {
                        System.IO.Directory.CreateDirectory(path + $@"\Upload\UploadFile\{dir}");
                    }
                    filename = path + $@"\Upload\UploadFile\{dir}\{filename1}";
                    size += file.Length;
                    using (FileStream fs = System.IO.File.Create(filename))
                    {
                        file.CopyTo(fs);
                        fs.Flush();
                    }
                    return Json(new { code = 200, msg = "上传成功", data = new { src = $"/Upload/UploadFile/{dir}/{filename1}", title = "图片标题" } });
                }
                return Json(new { code = 0, msg = "上传失败", });
                #endregion
            }
            catch (Exception)
            { 
                //throw;
            }
            return Json(new { code = 0, msg = "上传出错", });

        }
    }
}