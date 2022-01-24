from pymongo import MongoClient

from ResponseModel import ResponseModel


class DBHandler(object):
    def __init__(self):
        self.db = self.conectar()
        #self.collection = self.db.get_collection('Estudiantes')


    def conectar(self):
        client = MongoClient(
            host = 'infsalinas.sytes.net:10450',
            serverSelectionTimeoutMS = 3000,
            username = '2dam26',
            password = '52893970L',
            authSource = '2dam26'
        )
        db = client.get_database('2dam26')
        return db


    def insertarImagen(self, image):
        response = ResponseModel()
        try:
            self.collection = self.db.get_collection('Imagenes')
            self.collection.update_one({'_id':image['_id']},{'$push':{'imagenes':image['imagenes']}}, upsert=True)
            response.resultOk = True
            response.data = 'Imagen insertada con exito'
        except Exception as e:
            print(e)

        return response

    def obtenerImagenes(self, _idE):
        response = ResponseModel()
        try:
            self.collection = self.db.get_collection('Imagenes')
            imagenes = self.collection.find_one({'_id': _idE})

            if imagenes is None:
                print("ES NONE")
                response.resultOk = False
                response.data = "No hay imagenes"
            else:
                response.resultOk = True
                response.data = str(imagenes)


        except Exception as e:
            print(e)

        return response



    #######################################
    #ESTUDIANTES
    def eliminarProveedor(self,_idS):
        response = ResponseModel()

        try:
            self.collection = self.db.get_collection('Proveedores')
            self.collection.delete_one({'_id':_idS})
            response.resultOk = True
            response.data = 'Proveedor eliminado con exito'
        except Exception as e:
            print(e)

        return response

    def obtenerProveedor(self,_idS):
        response = ResponseModel()
        try:
            self.collection = self.db.get_collection('Proveedores')
            proveedor = self.collection.find_one({'_id':_idS})
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
            self.collection.update_one({'_id':proveedor['_id']},{'$set':proveedor})
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