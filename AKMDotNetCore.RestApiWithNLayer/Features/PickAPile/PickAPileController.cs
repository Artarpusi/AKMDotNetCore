using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AKMDotNetCore.RestApiWithNLayer.Features.PickAPile
{
    [Route("api/[controller]")]
    [ApiController]
    public class PickAPileController : ControllerBase
    {
        private async Task<PickAPile> GetDataAsync()
        {
            string jsonStr = await System.IO.File.ReadAllTextAsync("PickAPiledata.json");
            var model = JsonConvert.DeserializeObject<PickAPile>(jsonStr);
            return model;
        }

        // api/PickAPile/questions

        [HttpGet("questions")]
        public async Task<IActionResult> Questions()
        {
            var model = await GetDataAsync();
            return Ok(model.Questions);

        }

        [HttpGet("{questionNo}/{no}")]
        public async Task<IActionResult> Answer(int questionNo, int no)
        {
            var model = await GetDataAsync();
            return Ok(model.Answers.FirstOrDefault(x => x.QuestionId == questionNo && x.AnswerId == no));
        }
    }


    public class PickAPile
    {
        public Question[] Questions { get; set; }
        public Answer[] Answers { get; set; }
    }

    public class Question
    {
        public int QuestionId { get; set; }
        public string QuestionName { get; set; }
        public string QuestionDesp { get; set; }
    }

    public class Answer
    {
        public int AnswerId { get; set; }
        public string AnswerImageUrl { get; set; }
        public string AnswerName { get; set; }
        public string AnswerDesp { get; set; }
        public int QuestionId { get; set; }
    }
}
