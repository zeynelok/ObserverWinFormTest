# ObserverWinFormTest

-> Uygulamayı indirip çalıştırın.

-> Wrapper.cs'in içinde MessageHandler.cs new'lenerek provider oluşturuluyor ve ListBoard'a parametre olarak geçiliyor. 

-> ListBoard içinde 3 tane FlowPanel oluşturuluyor ve hepsine parametre olarak provider ve Type değeri veriliyor. FlowPanel constructor'unda provider'a subscribe olunuyor.

-> Wrapper ekranında input kısmına isim yazıp, combobox'dan type seçip Send butonuna tıkladığınızda ilgili metodlar tetiklenerek provider'ın MessageAdd metoduna girdiğiniz paremetreler iletilecek ve oradan da Messagehandler'a subscribe olmuş observer'lara bu mesaj iletilecek.

-> Mesajı alan observerlar yani FlowPaneller Type değerine göre kendine güncelleyecek

