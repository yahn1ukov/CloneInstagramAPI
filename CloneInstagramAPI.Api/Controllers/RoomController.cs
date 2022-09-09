using AutoMapper;
using CloneInstagramAPI.Application.Rooms.Commands;
using CloneInstagramAPI.Application.Rooms.Queries;
using CloneInstagramAPI.Contracts.Message;
using CloneInstagramAPI.Contracts.Room;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CloneInstagramAPI.Api.Controllers
{
    [Authorize(Roles = "USER")]
    [ApiController]
    [Route("api/rooms")]
    public class RoomController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public RoomController
        (
            IMediator mediator,
            IMapper mapper
        )
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost("users/{username}")]
        public async Task<IActionResult> CreateRoom(string username)
        {
            var command = new CreateRoomCommand(username);

            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRoomsUserByHttpContextId()
        {
            var query = new GetAllRoomsUserByHttpContextIdQuery();

            var result = await _mediator.Send(query);

            return Ok
            (
                result
                .Select(r => _mapper.Map<GetAllRoomsResponse>(r))
                .ToList()
            );
        }

        [HttpGet("{roomId}/messages")]
        public async Task<IActionResult> GetAllRoomMessagesById(Guid roomId)
        {
            var query = new GetAllRoomMessagesByIdQuery(roomId);

            var result = await _mediator.Send(query);

            return Ok
            (
                result
                .Select(r => _mapper.Map<GetAllMessagesResponse>(r))
                .ToList()
            );
        }

        [HttpDelete("{roomId}")]
        public async Task<IActionResult> DeleteRoomById(Guid roomId)
        {
            var command = new DeleteRoomByIdCommand(roomId);

            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpPost("{roomId}/messages")]
        public async Task<IActionResult> UpdateRoomAddMessageById(Guid roomId, AddMessageRequest request)
        {
            var command = new UpdateRoomAddMessageByIdCommand(roomId, request.Text);

            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpPatch("messages/{messageId}")]
        public async Task<IActionResult> UpdateRoomChangeMessageById(Guid messageId, ChangeMessageRequest request)
        {
            var command = new UpdateRoomChangeMessageByIdCommand(messageId, request.Text);

            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpDelete("messages/{messageId}")]
        public async Task<IActionResult> UpdateRoomDeleteMessageById(Guid messageId)
        {
            var command = new UpdateRoomDeleteMessageByIdCommand(messageId);

            var result = await _mediator.Send(command);

            return Ok(result);
        }
    }
}