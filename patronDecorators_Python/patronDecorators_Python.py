import sqlite3

def Fdecorator(fcrear):
    def fcreadora():
        print("Creando Base de Datos")
        
        fcrear()
        
        print("Base creada")
        
def Fdecorator2(fmodif):
    def fmodificador():
        print("Modificando Tabla")
        fmodif()
        print("Tabla modificada")

@Fdecorator()
def Conection():
    miConexion=sqlite3.connect("PrimeraBase")
    
    miCursor=miConexion.cursor()
    
    miCursor.execute("CREATE TABLE COSAS (NOMBRE VARCHAR(50),PRECIO INTEGER, SECCION VARCHAR(20))")
    

    miConexion.close()

@Fdecorator2()
def Modificator(Conection):
    miConexion=sqlite3.connect("PrimeraBase")
    miCursor=miConexion.cursor()
    miCursor.execute("INSERT INTO PRODUCTOS VALUES('BALON',15,'DEPORTES')")
    miConexion.commit()
    
def Cerrar(Conection):
    miConexion=sqlite3.connect("PrimeraBase")
    
    miConexion.close()

Conection()
Modificator()
Cerrar()

