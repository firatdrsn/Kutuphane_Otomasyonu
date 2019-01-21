--create database KutuphaneDemirbasVT

use KutuphaneDemirbasVT
    create table Sehir
  (
  Sehir_ID int primary key identity (1,1),
  Sehir_Adi varchar(20) not null,
  )

create table  Kullanici
(
 Kullanici_ID int primary key identity(1,1),
 Kullanici_Adi nvarchar(20) not null,
 Ad nvarchar (20) not null,
 Soyad nvarchar(25) not null,
 TC_No nchar(11)  constraint ck_TC_No check(TC_No LIKE '[1-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]') not null unique,
 Tel_No varchar(11)  constraint ck_Tel_No check(Tel_No like('[0][5][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]')) not null unique,
 Dogum_Tarihi date not null,
 Sehir_ID int constraint fk_Sehir foreign key references Sehir(Sehir_ID) not null,
 Adres nvarchar(60) not null
)

 create table Yetkiler
 (
 Yetki_ID int primary key identity (1,1),
 Yetki_Adý varchar(15)
 )
 create table Gizli_Soru
 (
 Gizli_Soru_ID int primary key identity (1,1),
 Gizli_Soru varchar(50)
 )

 create table Personel 
 (
   Personel_ID int primary key identity (1,1),
   Kullanici_ID int constraint  fk_Kullanici foreign key references Kullanici(Kullanici_ID) not null, 
   Yetki_ID int constraint  fk_Yetki foreign key references Yetkiler(Yetki_ID) not null,
   Sifre nvarchar(16) not null constraint ck_Sifre check (len(Sifre)>=5),
   Maas money not null,
   Ise_Bas_Tarihi date not null,
   Isten_Cikis_Tarihi date ,
   Gizli_Soru_ID int not null,
   Gizli_Cevap  nvarchar(20) not null
 )

 create table Yazarlar
  (
  Yazar_ID int primary key identity (1,1),
  Yazar_Adi varchar(30) not null,
  Yazar_Soyadi varchar(30) not null,
  Dogum_Tarihi date not null,
  Olum_Tarihi  date,    
  )

    create table YayinEvi
  (
  YayinEvi_ID int primary key identity (1,1),
  YayinEvi_Adi varchar(30) not null,
  YayinEvi_Adresi varchar(60),
  Bulundugu_Sehir int constraint fk_Sehir2 foreign key references Sehir(Sehir_ID) not null
  )

  create table Kategori
   (
   Kategori_ID int primary key identity (1,1),
   KategoriAd varchar(50) not null
   )

   create table Kitaplar
  (
   Kitap_ID int primary key identity(1,1),
   Kitap_Adi nvarchar(60) not null,
   Kitap_Basim_Yili date not null,
   Adet int constraint ck_Adet check(Adet>=0) not null,
   Yazar_ID int constraint fk_Yazarlar foreign key references Yazarlar(Yazar_ID) not null,
   Barkod_No nvarchar(max),
   YayinEvi_ID int constraint fk_YayinEvi foreign key references YayinEvi(YayinEvi_ID) NOT NULL,
   Kategori_ID int constraint fk_Kategori foreign key references Kategori(Kategori_ID) not null
  )

  create table Odunc 
  (
   Odunc_ID int primary key identity (1,1),
   Kitap_ID int constraint fk_Kitap_ID foreign key references Kitaplar(Kitap_ID) not null,
   Personel_ID int constraint fk_Personel_ID foreign key references Personel(Personel_ID) not null, 
   Kullanici_ID int constraint fk_Kullanici_ID foreign key references Kullanici(Kullanici_ID) not null,
   Yazar_ID int constraint fk_Yazar_ID foreign key references Yazarlar(Yazar_ID) not null,
   Alma_Tarihi date not null,
   Verme_Tarihi date,
  )

--SET IDENTITY_INSERT Kullanici  ON;

--Tablolara Veri Ekleniyor
INSERT INTO Sehir VALUES ('Ýstanbul')
  INSERT INTO Sehir VALUES ('Ankara')
  INSERT INTO Sehir VALUES ('Aðrý')
  INSERT INTO Sehir VALUES ('Moskova')
  INSERT INTO Sehir VALUES ('Pekin')

INSERT INTO dbo.Kullanici( Kullanici_Adi , Ad , Soyad, TC_No ,Tel_No ,Dogum_Tarihi , Sehir_ID, Adres) VALUES 
( 'sinan','sinan','kaya','10203040505','05378899898','01.02.2010',2,'ahmet necdet sezermah.'),
( 'ahmet','ahmet','turan','10203040506','05378899899','01.02.2010',2,'kuþçu mah.'),
('Personel1','Kullanýcý1_ad','Kullanýcý1_soyad','10203040507','05555555551','01.03.2012',1,'Mahalle1'),
('Personel2','Kullanýcý2_ad','Kullanýcý2_soyad','10203040508','05555555552','01.03.2012',3,'Mahalle2'),
('Kullanýcý3','Kullanýcý3_ad','Kullanýcý3_soyad','10203040509','05555555553','01.03.2012',4,'Mahalle3'),
('Kullanýcý4','Kullanýcý4_ad','Kullanýcý4_soyad','10203040510','05555555554','01.03.2012',2,'Mahalle4'),
('Kullanýcý5','Kullanýcý5_ad','Kullanýcý5_soyad','10203040511','05555555555','01.03.2012',1,'Mahalle5'),
('Kullanýcý6','Kullanýcý6_ad','Kullanýcý6_soyad','10203040512','05555555556','01.03.2012',3,'Mahalle6')

  INSERT INTO Yetkiler VALUES ('Admin'),('Müdür'),('Personel'),('Eski Personel'),('Eski Personel')
INSERT INTO Gizli_Soru VALUES ('En Yakýn Arkadaþýn'),('En Sevdiðin Öðretmenin'),('Beðendiðin PC Markasý'),('Uðurlu Sayýn')

 INSERT INTO dbo.Personel(Kullanici_ID,Yetki_ID,Sifre,Maas,Ise_Bas_Tarihi,Gizli_Soru_ID,Gizli_Cevap) VALUES 
(1,1,'123456','4000','2.11.2017',1,'admin'),
(2,2,'123457','3000','2.12.2018',2,'Müdür'),
(3,3,'123458','2000','2.12.2018',3,'Personel1'),
(4,3,'123459','2000','2.12.2018',3,'Personel2')

  INSERT INTO Yazarlar VALUES ('Yazar1_ad','Yazar1_soyad','01.01.1820','01.01.1860')
  INSERT INTO Yazarlar VALUES ('Yazar2_ad','Yazar2_soyad','01.01.1880','01.01.1960')
  INSERT INTO Yazarlar VALUES ('Yazar3_ad','Yazar3_soyad','01.01.1950',null)
  INSERT INTO Yazarlar VALUES ('Yazar4_ad','Yazar4_soyad','01.01.1980',null)

  INSERT INTO YayinEvi VALUES ('Yayin_Evi1','mahalle',1)
  INSERT INTO YayinEvi VALUES ('Yayin_Evi2','mahalle2',2)
  INSERT INTO YayinEvi VALUES ('Yayin_Evi3','mahalle3',3)
  INSERT INTO YayinEvi VALUES ('Yayin_Evi4','mahalle4',4)

  INSERT INTO dbo.Kategori VALUES ('Hikayeler')
    INSERT INTO dbo.Kategori VALUES ('Roman')
    INSERT INTO dbo.Kategori VALUES ('Dunya Klasikleri')
    INSERT INTO dbo.Kategori VALUES ('Felsefe')
	INSERT INTO dbo.Kategori VALUES ('Tiyatro')

 INSERT INTO dbo.Kitaplar(Kitap_Adi,Kitap_Basim_Yili, Adet,Yazar_ID,Barkod_No,YayinEvi_ID,Kategori_ID) VALUES 
( 'Canlar','01.02.1987',5,1,'11111',1,1),
('Kitap1','01.02.1846',1,1,'12222',1,1),
('Kitap2','01.02.1900',2,2,'22222',2,2),
('Kitap3','01.02.1910',3,3,'32222',3,3),
('Kitap4','01.02.1920',4,2,'42222',1,4),
('Kitap5','01.02.1930',5,3,'52222',2,1),
('Kitap6','01.02.1940',1,1,'62222',3,2),
('Kitap7','01.02.1950',2,1,'72222',1,3),
('Kitap8','01.02.1960',3,2,'82222',2,4),
('Kitap9','01.02.1970',0,3,'92222',3,1),
('Canlar','01.02.2000',3,4,'93333',3,2)
  

  INSERT INTO Odunc VALUES (1,2,4,1,'01.01.2018','01.02.2018')
  INSERT INTO Odunc VALUES (2,2,5,1,'01.01.2018','01.02.2018')
  INSERT INTO Odunc VALUES (3,3,6,2,'01.02.2018',null)
  INSERT INTO Odunc VALUES (4,3,7,3,'01.02.2018',null)
     
    

 --Silinenler tablosu oluþturuldu
 create table Silinen_Sehir
 (
 Sehir_ID int,
 Sehir_Adi varchar(20)
 )
  
  create table Silinen_Kullanici
  (
   Kullanici_ID int ,
 Kullanici_Adi nvarchar(20),
 Ad nvarchar (20) ,
 Soyad nvarchar(25),
 TC_No nchar(11)  ,
 Tel_No varchar(11) ,
 Dogum_Tarihi date ,
 Sehir_ID int ,
 Adres nvarchar(60) 
  )
  
  create table Silinen_Yetkiler
 (
 Yetki_ID int ,
 Yetki_Adý varchar(15)
 )

 create table Silinen_Gizli_Soru
 (
 Gizli_Soru_ID int ,
 Gizli_Soru varchar(50)
 )

  create table Silinen_Personel 
 (
   Personel_ID int ,
   Kullanici_ID int , 
   Yetki_ID int ,
   Sifre nvarchar(16) ,
   Maas money ,
   Ise_Bas_Tarihi date,
   Isten_Cikis_Tarihi date ,
   Gizli_Soru_ID int ,
   Gizli_Cevap  nvarchar(20) 
 )

 create table Silinen_Yazarlar
  (
  Yazar_ID int ,
  Yazar_Adi varchar(30) ,
  Yazar_Soyadi varchar(30) ,
  Dogum_Tarihi date ,
  Olum_Tarihi  date,    
  )

   create table Silinen_YayinEvi
  (
  YayinEvi_ID int,
  YayinEvi_Adi varchar(30) ,
  YayinEvi_Adresi varchar(60),
  Bulundugu_Sehir int 
  )

  create table Silinen_Kategori
   (
   Kategori_ID int ,
   KategoriAd varchar(50) 
   )

   create table Silinen_Kitaplar
  (
   Kitap_ID int ,
   Kitap_Adi nvarchar(60) ,
   Kitap_Basim_Yili date ,
   Adet int ,
   Yazar_ID int ,
   Barkod_No nvarchar(max),
   YayinEvi_ID int ,
   Kategori_ID int 
  )

  create table Silinen_Odunc 
  (
   Odunc_ID int ,
   Kitap_ID int ,
   Personel_ID int , 
   Kullanici_ID int ,
   Yazar_ID int,
   Alma_Tarihi date ,
   Verme_Tarihi date
  )


  -----------------------------------
  -----------------------------------
  -----------------------------------
Create trigger KitapSil on Kitaplar
instead of delete
as
begin
declare @Kitap_ID int,@Kitap_Adi nvarchar(60),@Kitap_Basim_Yili date,@Adet int,@Yazar_ID int,@Barkod_No nvarchar(max),@YayinEvi_ID int,@Kategori_ID int
select @Kitap_ID=(select Kitap_ID from deleted)
select @Kitap_Adi=(select Kitap_Adi from deleted)
select @Kitap_Basim_Yili=(select Kitap_Basim_Yili from deleted)
select @Adet=(select Adet from deleted)
select @Yazar_ID=(select Yazar_ID from deleted)
select @Barkod_No=(select Barkod_No from deleted)
select @YayinEvi_ID=(select YayinEvi_ID from deleted)
select @Kategori_ID=(select Kategori_ID from deleted)
insert into Silinen_Kitaplar values (@Kitap_ID,@Kitap_Adi,@Kitap_Basim_Yili,@Adet,@Yazar_ID,@Barkod_No,@YayinEvi_ID,@Kategori_ID)     
delete from Kitaplar where Kitap_ID=@Kitap_ID                     
end
  
create trigger KitapVer
on Odunc
after insert
as
begin
declare @Kitap_ID int
select @Kitap_ID=(select Kitap_ID from inserted)
update Kitaplar Set Adet=Adet-1 Where Kitap_ID=@Kitap_ID 
end


create trigger KitapAl
on Odunc
for update
as
begin
declare @Kitap_ID int
select @Kitap_ID=(select Kitap_ID from inserted)
update Kitaplar Set Adet=Adet+1 Where Kitap_ID=@Kitap_ID 
end

create trigger PersonelCikar
on Personel
for update
as
begin
declare @Personel int
select @Personel=(select Personel_ID from inserted)
update Personel Set Yetki_ID=4 Where Personel_ID=@Personel 
end

create proc sp_kitap_ara
(
 @brkt_nmrs nvarchar(max)
)
as 
begin
   select Kitap_Adi'Kitap Adý',Kitap_Basim_Yili'Basým Yýlý',Adet,Yazarlar.Yazar_Adi'Yazar',Barkod_No'Barkod Numarasý',YayinEvi.YayinEvi_Adi'Yayýn Evi',Kategori.KategoriAd'Kategori' From Kitaplar inner join Yazarlar On Kitaplar.Yazar_ID=Yazarlar.Yazar_ID inner join YayinEvi on Kitaplar.YayinEvi_ID=YayinEvi.YayinEvi_ID inner join Kategori on Kitaplar.Kategori_ID=Kategori.Kategori_ID where Barkod_No like '%'+@brkt_nmrs+'%'
end

--exec sp_kitap_ara 1

create proc sp_kitap_yazar_ara
(
 @kitap_adi nvarchar(60),
 @Yazar_adi varchar(30)
)
as 
begin
	select Kitap_Adi'Kitap Adý',Kitap_Basim_Yili'Basým Yýlý',Adet,Yazarlar.Yazar_Adi'Yazar',Barkod_No'Barkod Numarasý',YayinEvi.YayinEvi_Adi'Yayýn Evi',Kategori.KategoriAd'Kategori' From Kitaplar inner join Yazarlar On Kitaplar.Yazar_ID=Yazarlar.Yazar_ID inner join YayinEvi on Kitaplar.YayinEvi_ID=YayinEvi.YayinEvi_ID inner join Kategori on Kitaplar.Kategori_ID=Kategori.Kategori_ID where Kitaplar.Kitap_Adi like '%'+@kitap_adi+'%' and Yazarlar.Yazar_Adi like '%'+@Yazar_adi+'%' 
end


--exec sp_kitap_yazar_ara 'Canlar','Yazar1'

create proc sp_personel_ara
(
 @ad nvarchar(20)
)
as 
begin
	select Kullanici.Kullanici_Adi'Kullanýcý Adý',Kullanici.Ad'Adý',Kullanici.Soyad'Soyadý',Yetkiler.Yetki_Adý'Yetkisi',Maas'Maaþ',Ise_Bas_Tarihi'Ýþe Baþlama Tarihi',Isten_Cikis_Tarihi'Ýþten Çýkýþ Tarihi' From Personel inner join Kullanici On Personel.Kullanici_ID=Kullanici.Kullanici_ID inner join Yetkiler on Personel.Yetki_ID=Yetkiler.Yetki_ID where Kullanici.Ad like '%'+@ad+'%'
end

--exec sp_personel_ara sinan