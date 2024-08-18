using MediatR;
using Microsoft.AspNetCore.Mvc;
using TechnicalTest.Application.Users.Create;
using TechnicalTest.Application.Users.Delete;
using TechnicalTest.Application.Users.Get;
using TechnicalTest.Application.Users.GetAll;
using TechnicalTest.Application.Users.Login;
using TechnicalTest.Application.Users.Update;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<UserController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var listQuery = new GetAllUserQuery();
            var dtoList = await _mediator.Send(listQuery);
            return Ok(dtoList);
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var getUserQuery = new GetUserQuery(id);
            var dtoGet = await _mediator.Send(getUserQuery);
            return Ok(dtoGet);
        }

        // POST api/<UserController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateUserCommand createCommand)
        {
            var dtoCreate = await _mediator.Send(createCommand);
            return CreatedAtAction(nameof(Post), dtoCreate);
        }

        [Route("login")]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginCommand loginCommand)
        {
            // Por debajo usa el handler de LoginCommand
            var dtoLogin = await _mediator.Send(loginCommand);
            return Ok(dtoLogin);

        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] UpdateUserCommand updateUserCommand)
        {
            var updateCommand = new UpdateUserCommand(id, updateUserCommand.Name, updateUserCommand.Email, updateUserCommand.Password);
            await _mediator.Send(updateCommand);
            return Ok();
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deleteCommand = new DeleteUserCommand(id);
            await _mediator.Send(deleteCommand);
            return NoContent();
        }
    }
}
