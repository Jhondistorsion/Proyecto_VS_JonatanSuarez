from pymongo import MongoClient

from ResponseModel import ResponseModel
#

class DBHandler(object):
    def __init__(self):
        self.db = self.conectar()

    def conectar(self):
        client = MongoClient(
            host='infsalinas.sytes.net:10450',
            serverSelectionTimeoutMS=3000,
            username='2dam26',
            password='52893970L',
            authSource='2dam26'
        )
        db = client.get_database('2dam26')
        return db

    def comprobarLogin(self, _user):
        response = ResponseModel()
        try:
            self.collection = self.db.get_collection('Usuarios')
            usuario = self.collection.find_one({'User': _user['User'], 'Pass': _user['Pass']})
            if usuario != None:
                response.resultOk = True
            else:
                response.resultOk = False

        except Exception as e:
            print(e)

        return response

    #######################################
    # PROVEEDORES
    def eliminarProveedor(self, _idS):
        response = ResponseModel()

        try:
            self.collection = self.db.get_collection('Proveedores')
            self.collection.delete_one({'_id': _idS})
            response.resultOk = True
            response.data = 'Proveedor eliminado con exito'
        except Exception as e:
            print(e)

        return response

    def obtenerProveedor(self, _idS):
        response = ResponseModel()
        try:
            self.collection = self.db.get_collection('Proveedores')
            proveedor = self.collection.find_one({'_id': _idS})
            response.resultOk = True
            response.data = str(proveedor)
        except Exception as e:
            print(e)

        return response

    def actualizarProveedor(self, proveedor):
        response = ResponseModel()
        print(proveedor['Nombre'])

        try:
            self.collection = self.db.get_collection('Proveedores')
            self.collection.update_one({'_id': proveedor['_id']}, {'$set': proveedor})
            response.resultOk = True
            response.data = 'Proveedor actualizado con exito'
        except Exception as e:
            print(e)

        return response

    def obtenerProveedores(self):
        response = ResponseModel()
        try:
            self.collection = self.db.get_collection('Proveedores')
            listaProveedores = []
            coleccion = self.collection.find({})
            for proveedor in coleccion:
                listaProveedores.append(proveedor)

            response.resultOk = True
            response.data = str(listaProveedores)

        except Exception as e:
            print(e)

        return response

    def insertarProveedor(self, proveedor):
        response = ResponseModel()
        try:
            self.collection = self.db.get_collection('Proveedores')
            self.collection.insert_one(proveedor)
            response.resultOk = True
            response.data = 'Proveedor insertado con exito'
        except Exception as e:
            print(e)

        return response

    #######################################
    # PRODUCTOS

    def eliminarProducto(self, _idP):
        response = ResponseModel()

        try:
            self.collection = self.db.get_collection('Productos')
            self.collection.delete_one({'_id': _idP})
            response.resultOk = True
            response.data = 'Producto eliminado con exito'
        except Exception as e:
            print(e)

        return response

    def obtenerProducto(self, _idP):
        response = ResponseModel()
        try:
            self.collection = self.db.get_collection('Productos')
            producto = self.collection.find_one({'_id': _idP})
            response.resultOk = True
            response.data = str(producto)
        except Exception as e:
            print(e)

        return response

    def actualizarProducto(self, producto):
        response = ResponseModel()
        print(producto['Referencia'])

        try:
            self.collection = self.db.get_collection('Productos')
            self.collection.update_one({'_id': producto['_id']}, {'$set': producto})
            response.resultOk = True
            response.data = 'Producto actualizado con exito'
        except Exception as e:
            print(e)

        return response

    def obtenerProductos(self):
        response = ResponseModel()
        try:
            self.collection = self.db.get_collection('Productos')
            listaProductos = []
            coleccion = self.collection.find({})
            for producto in coleccion:
                listaProductos.append(producto)

            response.resultOk = True
            response.data = str(listaProductos)

        except Exception as e:
            print(e)

        return response

    def insertarProducto(self, producto):
        response = ResponseModel()
        try:
            self.collection = self.db.get_collection('Productos')
            self.collection.insert_one(producto)
            response.resultOk = True
            response.data = 'Producto insertado con exito'
        except Exception as e:
            print(e)

        return response
