public interface IRequestHandler<T extends IRequest> {
    Object execute(T request);
}
