using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DocumentsController : ControllerBase
    {
        private readonly Database.IDatabase _database;

        public DocumentsController(Database.IDatabase database)
        {
            _database = database;
        }

        [HttpGet]
        [Route("{id}")]
        [Produces("application/json", "application/xml"/*, "application/x-msgpack", "application/msgpack"*/)]
        public Document Get(string id)
        {
            var dbDoc = _database.GetDocument(id);
            if (dbDoc == null) { return new Document(); }

            return new Document()
            {
                Id = dbDoc.Id,
                Data = dbDoc.Data,
                Tags = dbDoc.Tags
            };
        }

        [HttpPost]
        public void Post(Document doc)
        {
            var dbDoc = new Database.Models.Document()
            {
                Id = doc.Id,
                Data = doc.Data,
                Tags = doc.Tags
            };

            _database.AddDocument(dbDoc);
        }

        [HttpPut]
        public void Put(Document doc)
        {
            var dbDoc = new Database.Models.Document()
            {
                Id = doc.Id,
                Data = doc.Data,
                Tags = doc.Tags
            };

            _database.UpdateDocument(dbDoc);
        }

        [HttpDelete]
        public void Delete(string id)
        {
            _database.RemoveDocument(id);
        }

    }
}
