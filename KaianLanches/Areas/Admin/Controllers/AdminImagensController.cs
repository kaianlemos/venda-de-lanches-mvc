using KaianLanches.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.IO;

namespace KaianLanches.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminImagensController : Controller
    {
        private readonly ConfigurationImagens _myConfig;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public AdminImagensController(IOptions<ConfigurationImagens> myConfig, IWebHostEnvironment webHostEnvironment)
        {
            _myConfig = myConfig.Value;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> UploadFiles(List<IFormFile> files)
        {
            if (files == null || files.Count == 0)
            {
                ViewData["Erro"] = "Erro: Arquivo(s) não selecionado(s)";
                return View(ViewData);
            }

            if (files.Count == 10)
            {
                ViewData["Erro"] = "Erro: Quantidade de arquivos excedeu o limite";
                return View(ViewData);
            }

            long size = files.Sum(f => f.Length);

            var filePathSName = new List<string>();

            var filePath = Path.Combine(_webHostEnvironment.WebRootPath, _myConfig.NomePastaImagensProdutos);

            foreach (var formFile in files)
            {
                if (formFile.FileName.Contains(".jpg") || formFile.FileName.Contains(".png") || formFile.FileName.Contains(".gif"))
                {
                    var fileNameWithPath = string.Concat(filePath, "\\", formFile.FileName);

                    filePathSName.Add(fileNameWithPath);

                    using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
                    {
                        await formFile.CopyToAsync(stream);
                    }
                }
            }

            ViewData["Resultado"] = $"{files.Count} arquivos foram enviados ao servidor, " + $"com tamanho total de: {size} bytes";
            return View(ViewData);
        }

        public IActionResult GetImagens()
        {
            FileManagerModel model = new FileManagerModel();

            var userImagesPath = Path.Combine(_webHostEnvironment.WebRootPath, _myConfig.NomePastaImagensProdutos);

            DirectoryInfo dir = new DirectoryInfo(userImagesPath);

            FileInfo[] files = dir.GetFiles();

            model.PathImagesProduto = _myConfig.NomePastaImagensProdutos;

            if (files.Length == 0)
            {
                ViewData["Erro"] = $"Nenhum arquivo encontrado na pasta {userImagesPath}";
            }

            model.Files = files;

            return View(model);
        }

        public IActionResult DeleteFile(string fname)
        {
            string _imagemDeleta = Path.Combine(_webHostEnvironment.WebRootPath, _myConfig.NomePastaImagensProdutos);

            if (System.IO.File.Exists(_imagemDeleta))
            {
                System.IO.File.Delete(_imagemDeleta);

                ViewData["Deletado"] = $"Arquivo(s) {_imagemDeleta} deletado com sucesso!";
            }

            return View("index");
        }
    }
}
