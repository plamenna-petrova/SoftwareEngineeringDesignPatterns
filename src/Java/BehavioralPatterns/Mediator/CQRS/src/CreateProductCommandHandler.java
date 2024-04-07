public class CreateProductCommandHandler implements IRequestHandler<CreateProductCommand> {
    @Override
    public Object execute(CreateProductCommand createProductCommand) {
        System.out.println("Creating the product: " + createProductCommand.getName());
        return true;
    }
}
