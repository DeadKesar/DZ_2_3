using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.srp
{
    class Case1
    {
        public class Channel
        {
            private string _host;
            public Channel(string host)
            {
                this._host = host;
            }

            public void SendMessage(string source, string dest, string message)
            {
                Console.WriteLine($"[SEND {_host}] {source} - {dest}: {message};");
            }
        }

        public class Client
        {
            private Guid _id;
            private string _fullName;
            private Channel _channel;

            public string Name
            {
                get { return _fullName; }
            }

            public Client(Guid id, string fullName, Channel channel)
            {
                _id = id;
                _fullName = fullName;
                _channel = channel;
            }

            public string GetCurrentRenderedState()
            {
                return $"<id>{_id}</id>\n<fullname>{_fullName}</fullname>";
            }

            public void SendMessageToClient(Client dest, string message)
            {
                _channel.SendMessage(Name, dest.Name, message);
            }
        }

    }

    //класс Client нарушал приницп SRP
    //вынес отправку сообщений в отдельный класс MessageService
    //добавил интерфейс IMessageChannel чтобы не было зависимости от класса Channel, т.е. нарушение DIP
    class Case1Fixed 
    {
        //интерфейс с методом SendMessage
        public interface IMessageChannel
        {
            void SendMessage(string source, string dest, string message);
        }
        
        public class Channel:IMessageChannel
        {
            private string _host;
            public Channel(string host)
            {
                this._host = host;
            }

            public void SendMessage(string source, string dest, string message)
            {
                Console.WriteLine($"[SEND {_host}] {source} - {dest}: {message};");
            }
        }

        public class Client
        {
            private Guid _id;
            private string _fullName;

            public string Name
            {
                get { return _fullName; }
            }

            public Client(Guid id, string fullName)
            {
                _id = id;
                _fullName = fullName;
            }

            public string GetCurrentRenderedState()
            {
                return $"<id>{_id}</id>\n<fullname>{_fullName}</fullname>";
            }
        }

        public class MessageService
        {
            private readonly IMessageChannel _channel;  
            
            public MessageService(IMessageChannel channel)  
            {
                _channel = channel;
            }
            
            public void SendMessageToClient(Client sender, Client receiver, string message)
            {
                _channel.SendMessage(sender.Name, receiver.Name, message);
            }
        }
    }
}
