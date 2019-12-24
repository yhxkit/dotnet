using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace test191218.Controllers
{
    public class UploadController : Controller
    {

        private readonly IHostingEnvironment _environment; //인젝션 받기

        public UploadController(IHostingEnvironment environment)
        {
            _environment = environment;
        }

        //근데 이걸로 해도 무거운 이미지 올리고 있을때 다른 액션 잘 작동하는데...?
        //[HttpPost]
        //[Route("api/upload")] //루트/api/upload 주소로 라우트
        //public IActionResult ImageUpload(IFormFile fileToUpload)
        //{
        //    //이미지나 파일 업로드할때에 필요한 구성
        //    //1. 어디 저장할지에 대한 path 
        //    //2. 저장될 파일의 이름. 겹치면 안됨 덮어쓰니까
        //    //3. 확장자

        //    var path = Path.Combine(_environment.WebRootPath, @"images\upload"); // wwwroot 경로
        //    var fileName = fileToUpload.FileName; //확장자 포함한 파일명



        //    using (var fileStream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
        //    {
        //        fileToUpload.CopyTo(fileStream); //이미지 사이즈 클 경우 병목현상 발생 > 비동기적 처리 필요 
        //    }

        //    return Ok(new { file = "/images/upload/" + fileName, success = true });
        //}



        [HttpPost]
        [Route("api/upload")] //루트/api/upload 주소로 라우트
        public async Task<IActionResult> ImageUpload(IFormFile fileToUpload)
        {
            //이미지나 파일 업로드할때에 필요한 구성
            //1. 어디 저장할지에 대한 path 
            //2. 저장될 파일의 이름. 겹치면 안됨 덮어쓰니까
            //3. 확장자

            var path = Path.Combine(_environment.WebRootPath, @"images\upload"); // wwwroot 경로
                                                                                 //var fileName = fileToUpload.FileName; //확장자 포함한 파일명
            var fileFullName = fileToUpload.FileName.Split(".");
            var fileName = $"{Guid.NewGuid()}.{fileFullName[1]}";//guid를 사용할 거라서 스트링 포맷 사용 $"{}" 기존 파일명을 guid로 스위치하고 확장자를 붙여서 새로운 파일명

            using (var fileStream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
            {
                await fileToUpload.CopyToAsync(fileStream); //이미지 사이즈 클 경우 병목현상 발생 > 비동기적 처리 필요 
            }

            return Ok(new { file = "/images/upload/" + fileName, success = true });
        }







    }
}
