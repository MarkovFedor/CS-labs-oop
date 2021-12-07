using System;
using Banks.BankStructures;
using Banks.Clients;
using Banks.Transactions;
namespace Banks.CLI
{
    public class Application
    {
        private CentralBank _centralBank;
        public Application()
        {
        }

        public void Start()
        {
            Console.WriteLine("INFO: Приложение запущено");
            Resume();
        }

        public void Reset()
        {
            _centralBank = null;
        }

        private void Resume()
        {
            while (true)
            {
                Console.Write(">> ");
                string argument = Console.ReadLine();
                switch (argument)
                {
                    case "/help":
                        Help();
                        break;
                    case "/createcentralbank":
                        CentralBankCreate();
                        break;
                    case "/createbank":
                        BankCreate();
                        break;
                    case "/registerclient":
                        RegisterClient();
                        break;
                    case "/editclient":
                        EditClient();
                        break;
                    case "/editbank":
                        EditBank();
                        break;
                    case "/transaction":
                        ProvideTransaction();
                        break;
                }
            }
        }

        private void CentralBankCreate()
        {
            _centralBank = new CentralBank();
        }

        private void BankCreate()
        {
            Console.WriteLine("Введите название банка");
            Console.Write(">> ");
            string name = Console.ReadLine();
            Bank bank = _centralBank.CreateBank(name);
            Console.WriteLine("Введите процент по депозиту");
            Console.Write(">> ");
            string depositePercent = Console.ReadLine();
            int percent = int.Parse(depositePercent);
            bank.SetDailyDepositePercent(percent / 30);
            Console.WriteLine("Введите лимит на переводы");
            Console.Write(">> ");
            string limitString = Console.ReadLine();
            int limit = int.Parse(limitString);
            bank.SetTransferLimit(limit);
            Console.WriteLine("Введите комиссию");
            Console.Write(">> ");
            string commissionString = Console.ReadLine();
            int commission = int.Parse(commissionString);
            bank.SetCommission(commission);
            Console.WriteLine("Введите кредитный лимит");
            Console.Write(">> ");
            string creditLimitString = Console.ReadLine();
            int creditLimit = int.Parse(creditLimitString);
            bank.SetCreditLimit(creditLimit);
            Console.WriteLine("Введите лимит на снятие");
            Console.Write(">> ");
            string withdrawLimitString = Console.ReadLine();
            int withdrawLimit = int.Parse(withdrawLimitString);
            bank.SetWithdrawLimit(withdrawLimit);
        }

        private void RegisterClient()
        {
            Console.WriteLine("Введите имя (обязательно");
            Console.Write(">> ");
            string name = Console.ReadLine();
            Console.WriteLine("Введите фамилию(обязательно");
            Console.Write(">> ");
            string surname = Console.ReadLine();
            Console.WriteLine("Введите адрес или нажмите enter");
            Console.Write(">> ");
            string address = Console.ReadLine();
            Console.WriteLine("Введите паспорт или нажмите enter");
            Console.Write(">> ");
            string passport = Console.ReadLine();
            _centralBank.RegisterClient(name, surname, address, passport);
        }

        private void EditClient()
        {
            Console.WriteLine("Введите имя и фамилию клиента");
            Console.Write(">> ");
            string name = Console.ReadLine();
            Console.Write(">> ");
            string surname = Console.ReadLine();
            Client client = _centralBank.FindClient(name, surname);
            Console.WriteLine("Добавьте пасспорт");
            Console.Write(">> ");
            string passport = Console.ReadLine();
            Console.WriteLine("Добавьте адрес");
            Console.Write(">> ");
            string address = Console.ReadLine();
            client.SetAddress(address);
            client.SetPassport(passport);
            Console.WriteLine(client.Info());
        }

        private void EditBank()
        {
            Console.WriteLine("Выберите банк для редактирования");
            Console.Write(">> ");
            string name = Console.ReadLine();
            Bank bank = _centralBank.FindBank(name);
            Console.WriteLine("Выберите поле для редактирования");
            Console.WriteLine("1. Проценты на депозит");
            Console.WriteLine("2. Лимит на перевод");
            Console.WriteLine("3. Коммиссия");
            Console.WriteLine("4. Лимит на кредит");
            Console.WriteLine("5. Лимит на снятие");
            string fieldString = Console.ReadLine();
            int field = int.Parse(fieldString);
            switch (field)
            {
                case 1:
                    Console.Write(">> ");
                    string depositeString = Console.ReadLine();
                    int deposite = int.Parse(depositeString);
                    bank.SetDailyDepositePercent(deposite / 30);
                    break;
                case 2:
                    Console.Write(">> ");
                    string limitString = Console.ReadLine();
                    int limit = int.Parse(limitString);
                    bank.SetTransferLimit(limit);
                    break;
                case 3:
                    Console.Write(">> ");
                    string commissionString = Console.ReadLine();
                    int commission = int.Parse(commissionString);
                    bank.SetCommission(commission);
                    break;
                case 4:
                    Console.Write(">> ");
                    string creditLimieString = Console.ReadLine();
                    int creditLimit = int.Parse(creditLimieString);
                    bank.SetCreditLimit(creditLimit);
                    break;
                case 5:
                    Console.Write(">> ");
                    string withdrawLimitString = Console.ReadLine();
                    int withdrawLimit = int.Parse(withdrawLimitString);
                    bank.SetWithdrawLimit(withdrawLimit);
                    break;
            }
        }

        private void ProvideTransaction()
        {
            Console.WriteLine("Выберите тип транзации");
            Console.WriteLine("1. Перевод");
            Console.WriteLine("2. Снятие");
            Console.WriteLine("3. Пополнение");
            Console.Write(">> ");
            string name;
            string surname;
            string bankName;
            Bank bank;
            string idString;
            int id;
            string bankNameRaise;
            Bank bankRaise;
            string amountString;
            string argumentString = Console.ReadLine();
            int argument = int.Parse(argumentString);
            switch (argument)
            {
                case 1:
                    Console.WriteLine("Введите имя и фамилию клмента от которого будет перевод");
                    Console.Write(">> ");
                    name = Console.ReadLine();
                    Console.Write(">> ");
                    surname = Console.ReadLine();
                    Client client = _centralBank.FindClient(name, surname);
                    Console.WriteLine("Введите банк в котором счет снятия");
                    Console.Write(">> ");
                    bankName = Console.ReadLine();
                    bank = _centralBank.FindBank(bankName);
                    Console.WriteLine("Введите счет для снятия");
                    Console.Write(">> ");
                    idString = Console.ReadLine();
                    id = int.Parse(idString);
                    Console.WriteLine("Введите банк в котором счет пополнения");
                    Console.Write(">> ");
                    bankNameRaise = Console.ReadLine();
                    bankRaise = _centralBank.FindBank(bankNameRaise);
                    Console.WriteLine("Введите счет для пополнения");
                    Console.Write(">> ");
                    string idRaiseString = Console.ReadLine();
                    int idRaise = int.Parse(idRaiseString);
                    Console.WriteLine("Сумма перевода");
                    Console.Write(">> ");
                    amountString = Console.ReadLine();
                    int amount = int.Parse(amountString);
                    _centralBank.DoTransaction(new Transfer(client, bank, id, bankRaise, idRaise, amount));
                    break;
                case 2:
                    Console.WriteLine("Введите имя и фамилию клмента который будет снимать");
                    Console.Write(">> ");
                    name = Console.ReadLine();
                    Console.Write(">> ");
                    surname = Console.ReadLine();
                    client = _centralBank.FindClient(name, surname);
                    Console.WriteLine("Введите банк в котором счет снятия");
                    Console.Write(">> ");
                    bankName = Console.ReadLine();
                    bank = _centralBank.FindBank(bankName);
                    Console.WriteLine("Введите счет для снятия");
                    Console.Write(">> ");
                    idString = Console.ReadLine();
                    id = int.Parse(idString);
                    Console.WriteLine("Сумма снятия");
                    Console.Write(">> ");
                    amountString = Console.ReadLine();
                    amount = int.Parse(amountString);
                    _centralBank.DoTransaction(new Withdraw(client, amount, bank, id));
                    break;
                case 3:
                    Console.WriteLine("Введите имя и фамилию клмента который будет пополнять");
                    Console.Write(">> ");
                    name = Console.ReadLine();
                    Console.Write(">> ");
                    surname = Console.ReadLine();
                    client = _centralBank.FindClient(name, surname);
                    Console.WriteLine("Введите банк в котором счет пополнения");
                    Console.Write(">> ");
                    bankName = Console.ReadLine();
                    bank = _centralBank.FindBank(bankName);
                    Console.WriteLine("Введите счет для пополнения");
                    Console.Write(">> ");
                    idString = Console.ReadLine();
                    id = int.Parse(idString);
                    Console.WriteLine("Сумма пополнения");
                    Console.Write(">> ");
                    amountString = Console.ReadLine();
                    amount = int.Parse(amountString);
                    _centralBank.DoTransaction(new Replenishment(amount, client, bank, id));
                    break;
            }
        }

        private void Help()
        {
            Console.WriteLine("/help                -показать меню help");
            Console.WriteLine("/createcentralbank   -создать центральный банк");
            Console.WriteLine("/createbank          -создать банк");
            Console.WriteLine("/registerclient      -зарегистрировать клиента");
            Console.WriteLine("/editclient          -редактировать клиента");
            Console.WriteLine("/editbank            -редактировать банк");
            Console.WriteLine("/transaction         -осуществить транзакцию");
        }
    }
}
