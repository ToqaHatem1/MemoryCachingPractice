//using Microsoft.AspNetCore.Mvc;
//using StackExchange.Redis;

//namespace ProductCachingPractice.Controllers
//{
//    [ApiController]
//    [Route("api/[controller]")]
//    public class RedisController : ControllerBase
//    {
//        private readonly IConnectionMultiplexer _redis;

//        public RedisController(IConnectionMultiplexer redis)
//        {
//            _redis = redis;
//        }

//        [HttpGet("test")]
//        public async Task<IActionResult> Test()
//        {
//            var db = _redis.GetDatabase();
//            await db.StringSetAsync("message", "Hello, Redis!");
//            var value = await db.StringGetAsync("message");
//            return Ok(value.ToString());
//        }
//    }
//}
