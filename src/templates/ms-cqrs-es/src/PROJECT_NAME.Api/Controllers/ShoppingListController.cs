using MediatR;
using Microsoft.AspNetCore.Mvc;
using PROJECT_NAME.Application.Commands;
using PROJECT_NAME.Application.Queries;

namespace PROJECT_NAME.ApiControllers;

[ApiController]
[Route("[controller]")]
public class ShoppingListController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ILogger<ShoppingListController> _logger;

    public ShoppingListController(
        IMediator mediator,
        ILogger<ShoppingListController> logger)
    {
        _mediator = mediator;
        _logger = logger;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllShoppingLists()
    {
        var result = await _mediator.Send(new GetAllShoppingListsQuery());
        return result.Match<IActionResult>(
            i => new OkObjectResult(i),
            (ex, msg) => new BadRequestObjectResult(msg));
    }
    
    [HttpPost]
    [Route("create")]
    public async Task<IActionResult> CreateShoppingListCommand([FromBody] CreateShoppingListCommand command)
    {
        var result = await _mediator.Send(command);
        return result.Match<IActionResult>(
            i => new OkObjectResult(i),
            (ex, msg) => new BadRequestObjectResult(msg));
    }
    
    [HttpPost]
    [Route("add/item")]
    public async Task<IActionResult> AddItemToShoppingList([FromBody] AddItemToShoppingListCommand command)
    {
        var result = await _mediator.Send(command);
        return result.Match<IActionResult>(
            i => new OkObjectResult(i),
            (ex, msg) => new BadRequestObjectResult(msg));
    }
    
    [HttpPost]
    [Route("remove/item")]
    public async Task<IActionResult> RemoveItemToShoppingList([FromBody] RemoveItemFromShoppingListCommand command)
    {
        var result = await _mediator.Send(command);
        return result.Match<IActionResult>(
            i => new OkObjectResult(i),
            (ex, msg) => new BadRequestObjectResult(msg));
    }
}