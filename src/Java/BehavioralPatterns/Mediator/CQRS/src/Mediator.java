import java.lang.reflect.InvocationTargetException;
import java.util.Map;

public class Mediator implements IMediator {
    private final Map<Class<?>, Class<?>> requestHandlers;

    public Mediator(Map<Class<?>, Class<?>> requestHandlers) {
        this.requestHandlers = requestHandlers;
    }

    @Override
    public Object send(IRequest request) {
        Class<? extends IRequestHandler<? extends IRequest>> requestHandlerType = (Class<? extends IRequestHandler<? extends IRequest>>) requestHandlers.get(request.getClass());
        try {
            assert requestHandlerType != null;
            IRequestHandler<? extends IRequest> requestHandler = requestHandlerType.getDeclaredConstructor().newInstance();
            return requestHandler.getClass().getMethod("execute", request.getClass()).invoke(requestHandler, request);
        } catch (InstantiationException | IllegalAccessException | InvocationTargetException | NoSuchMethodException exception) {
            exception.printStackTrace();
        }
        return null;
    }
}
