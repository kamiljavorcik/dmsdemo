using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DocumentsController : ControllerBase
    {
        private readonly ILogger<DocumentsController> _logger;
        private readonly Service.IService _service;

        public DocumentsController(ILogger<DocumentsController> logger, Service.IService service)
        {
            _logger = logger;
            _service = service;

            _service.Init();
        }

        [HttpGet]
        [Route("{name}")]
        public Document Get(string name)
        {
            var svcDoc = new Service.Models.Document()
            {
                Id = 0,
                Name = name
            };

            var res = _service.GetDocument(svcDoc) ?? new Service.Models.Document()
            {
                Tags = new List<Service.Models.Tag>(),
                Datas = new List<Service.Models.Data>(),
            };

            return new Document()
            {
                Id = res.Id,
                Name = res.Name,
                Tags = res.Tags.Select(y => new Tag() { Id = y.Id, Name = y.Name }).ToList(),
                Datas = res.Datas.Select(y => new Data() { Id = y.Id, Name = y.Name, Type = y.Type, Content = y.Content }).ToList(),
            };
        }

        [HttpPost]
        public void Post(Document doc)
        {
            var svcDoc = new Service.Models.Document()
            {
                /*Id = doc.Id,*/
                Name = doc.Name,
                Tags = doc.Tags.Select(y => new Service.Models.Tag() { /*Id = y.Id,*/ Name = y.Name }).ToList(),
                Datas = doc.Datas.Select(y => new Service.Models.Data() { /*Id = y.Id,*/ Name = y.Name, Type = y.Type, Content = y.Content }).ToList(),
            };

            _service.AddDocument(svcDoc);

        }

        [HttpPut]
        public void Put(Document doc)
        {
            var svcDoc = new Service.Models.Document()
            {
                Id = doc.Id,
                Name = doc.Name,
                Tags = doc.Tags.Select(y => new Service.Models.Tag() { Id = y.Id, Name = y.Name }).ToList(),
                Datas = doc.Datas.Select(y => new Service.Models.Data() { Id = y.Id, Name = y.Name, Type = y.Type, Content = y.Content }).ToList(),
            };

            _service.UpdateDocument(svcDoc);
        }

        [HttpDelete]
        public void Delete(Document doc)
        {
            var svcDoc = new Service.Models.Document()
            {
                Id = doc.Id,
                Name = doc.Name,
                Tags = doc.Tags.Select(y => new Service.Models.Tag() { Id = y.Id, Name = y.Name }).ToList(),
                Datas = doc.Datas.Select(y => new Service.Models.Data() { Id = y.Id, Name = y.Name, Type = y.Type, Content = y.Content }).ToList(),
            };

            _service.RemoveDocument(svcDoc);
        }

    }
}
