using Yatzy.Decoration;
using Yatzy.Errors;

namespace Yatzy.Tests.Core.DecorationTests;
public class WrappingContextTests
{
    readonly ITestOutputHelper output;
    public WrappingContextTests(ITestOutputHelper output)
    {
        this.output = output;
    }
    [Fact]
    public void Ctor_NonAbsraction_ThrowsException()
    {
        Faulty implementor = new();
        Action act = () => _ = new WrapperContext<Faulty>(implementor);
        act.Should().Throw<NonAbstractionTypeParam<Faulty>>();
    }
    [Fact]
    public void Ctor_AbstractClass_DoesNotThrowException()
    {
        AbstractImplementor implementor = new();
        Action act = () => _ = new WrapperContext<AbstractClass>(implementor);
        act.Should().NotThrow<NonAbstractionTypeParam<AbstractClass>>();
    }
    [Fact]
    public void Ctor_Interface_DoesNotThrowException()
    {
        InterfaceImplementor implementor = new();
        Action act = () => _ = new WrapperContext<IInterface>(implementor);
        act.Should().NotThrow<NonAbstractionTypeParam<IInterface>>();
    }
    [Fact]
    public void Context_Value_ContainsValue()
    {
        IInterface expected = new InterfaceImplementor();
        WrapperContext<IInterface> context = new(expected);
        output.WriteResult(expected, context.Context);
        context.Context.Should().BeSameAs(expected);
    }
    [Fact]
    public void Context_NoValue_ContainsNull()
    {
        WrapperContext<IInterface> context = new();
        output.WriteExpectedNull(context.Context);
        context.Context.Should().BeNull();
    }
    class Faulty : IDecoratable
    {
        public Type LogType => throw new NotImplementedException();
    }
    interface IInterface : IDecoratable
    {
    }
    abstract class AbstractClass : IDecoratable
    {
        public abstract Type LogType { get; }
    }
    class InterfaceImplementor : IInterface
    {
        public Type LogType => throw new NotImplementedException();
    }
    class AbstractImplementor : AbstractClass
    {
        public override Type LogType => throw new NotImplementedException();
    }

}
