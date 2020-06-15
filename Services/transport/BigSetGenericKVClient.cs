using System;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BooksApi.Models;
using Newtonsoft.Json;
using org.openstars.core.bigset.Generic;
using ThriftPoolDotNet;

namespace BooksApi.Services.transport
{
    public class BigSetGenericKVClient
    {
        const string BsKey = "Test";
        private static TStringBigSetKVService.Client aClient;
        private static int ie = 0;
        static readonly object _object = new object();

        static public void put(int  id)
        {
            lock (_object)
            {
                BigSetClient objBigSet = new BigSetClient("127.0.0.1", 18407, false);
                Console.WriteLine("objBigSet = " + objBigSet);
                TClientInfo clientInfo = objBigSet.getClient();
                Console.WriteLine("clientInfo.isOpen() " + clientInfo.isOpen());
                if (!clientInfo.isOpen())
                {
                
                    clientInfo.doOpen();
                    Console.WriteLine("clientInfo.isOpen()2 " + clientInfo.isOpen());
                }
            
                if (!clientInfo.sureOpen())
                {
                    Console.WriteLine("I0");
                    Thread.Sleep(1*100);
                    if (!clientInfo.sureOpen())
                    {
                        Console.WriteLine("clientInfo.sureOpen() " + clientInfo.sureOpen());
                        Console.WriteLine("Can't open");
                        ie++;
                        return;
                    }
                } 
                //var aRes;
                object tmp = clientInfo.getClient();
                Console.WriteLine(ClientFactory.getCountTotalClient() + ": ClientFactory.getCountTotalClient()");
                Console.WriteLine("tmp = " + tmp);
                aClient = (TStringBigSetKVService.Client) tmp;
                
                
                Book book = new Book();
                book.Author = "Auth";
                book.Category = "Category";
                book.Id = ""+id;
                book.Price = 10123;
                book.BookName = "Book Name";

                var bookJson = JsonConvert.SerializeObject(book);
                var bJson = Encoding.ASCII.GetBytes(bookJson);
                ;
                var str = Encoding.UTF8.GetString(bJson);
                // Console.WriteLine(bJson);
                Console.WriteLine(str);
                var tItem = new TItem();
                tItem.Key = Encoding.ASCII.GetBytes(book.Id);
                tItem.Value = bJson;

                var bsPutItemAsync = aClient.bsPutItemAsync(BsKey, tItem);
                Console.WriteLine(bsPutItemAsync.IsCompleted);
                if (bsPutItemAsync.IsCompleted == false)
                {
                    bsPutItemAsync.Wait();
                }
                clientInfo.cleanUp();
            }
            
        }

        static public void get(string bookid)
        {
            lock (_object)
            { 
            BigSetClient objBigSet = new BigSetClient("127.0.0.1", 18407, false);
            //Console.WriteLine("objBigSet = " + objBigSet);
            TClientInfo clientInfo = objBigSet.getClient();
            //Console.WriteLine("clientInfo.isOpen() " + clientInfo.isOpen());
            if (!clientInfo.isOpen())
            {
                
                clientInfo.doOpen();
                //Console.WriteLine("clientInfo.isOpen()2 " + clientInfo.isOpen());
            }
            
            if (!clientInfo.sureOpen())
            {
                //Console.WriteLine("I0");
                Thread.Sleep(1*100);
                if (!clientInfo.sureOpen())
                {
                    //Console.WriteLine("clientInfo.sureOpen() " + clientInfo.sureOpen());
                    Console.WriteLine("Can't open");
                    ie++;
                    return;
                }
            } 
            //var aRes;
            object tmp = clientInfo.getClient();
            aClient = (TStringBigSetKVService.Client) tmp;
            Task<TItemResult> bsGetItemAsync = aClient.bsGetItemAsync(BsKey, Encoding.ASCII.GetBytes(bookid));
            if (bsGetItemAsync.IsCompleted == false)
            {
                //Console.WriteLine("error");
                //Console.WriteLine("bsGetItemAsync.IsCompleted == false");
                bsGetItemAsync.Wait();
            }

            //convert
            var Bbook = bsGetItemAsync.Result.Item.Value;
            Book book = ConvertItemtoBook(Bbook);
            Console.WriteLine("Book: " + book.Id);
            // Console.WriteLine(book.BookName);
            // Console.WriteLine(book.Author);
            // Console.WriteLine(book.Category);
            // Console.WriteLine(book.Price);
            
            clientInfo.cleanUp();
            }
        }

        static public Book ConvertItemtoBook(byte[] bbook)
        {
            string str = Encoding.UTF8.GetString(bbook);
            Book book = (Book) JsonConvert.DeserializeObject(str, typeof(Book));
            return book;
        }

        public static void Main()
        {
            test();
            //get("123123", 500);
            Thread.Sleep(5 * 1000);
            Console.WriteLine("ClientFactory.getCountTotalClient() " + ClientFactory.getCountTotalClient());
            Console.WriteLine(ie);
        }

        private static void test()
        {
            //=====================================
            //get
            Thread t1 = new Thread(() =>
            {
                for (int i = 0; i < 30; i++)
                {
                    ThreadStart start = new ThreadStart(() => get(""+i));  
                    new Thread(start).Start(); 
                }
            });
            Thread t2 = new Thread(() =>
            {
                for (int i = 30; i < 60; i++)
                {
                    ThreadStart start = new ThreadStart(() => get(""+i));  
                    new Thread(start).Start(); 
                }
            });
            Thread t3 = new Thread(() =>
            {
                for (int i = 60; i < 90; i++)
                {
                    ThreadStart start = new ThreadStart(() => get(""+i));  
                    new Thread(start).Start(); 
                }
            });
            t1.Start();
            t2.Start();
            t3.Start(); 
            
            t1.Join();
            t2.Join();
            t3.Join();
            
            //=============================================================================
            //push()
            // Thread t1 = new Thread(() =>
            // {
            //     for (int i = 0; i < 30; i++)
            //     {
            //         ThreadStart start = new ThreadStart(() => put(i));  
            //         new Thread(start).Start(); 
            //     }
            // });
            // Thread t2 = new Thread(() =>
            // {
            //     for (int i = 30; i < 60; i++)
            //     {
            //         ThreadStart start = new ThreadStart(() => put(i));  
            //         new Thread(start).Start(); 
            //     }
            // });
            // Thread t3 = new Thread(() =>
            // {
            //     for (int i = 60; i < 90; i++)
            //     {
            //         ThreadStart start = new ThreadStart(() => put(i));  
            //         new Thread(start).Start(); 
            //     }
            // });
            // t1.Start();
            // t2.Start();
            // t3.Start(); 
            //
            // t1.Join();
            // t2.Join();
            // t3.Join();




            //
            // get("123123");
            // Console.WriteLine(ClientFactory.getCountTotalClient());
        }
    }
}