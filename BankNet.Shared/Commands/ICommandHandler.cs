using System.Threading.Tasks;

namespace BankNet.Shared.Commands
{
    public interface ICommandHandler<T> where T: ICommand
    {
        Task<ICommandResult> Handle(T command);
    }
}
