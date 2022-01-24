import json
from datetime import datetime
from hashlib import sha256

from flask import Flask, request

from DBHandler import DBHandler
from ResponseModel import ResponseModel

app = Flask(__name__)

PASS = "52893970L"

def checkTokenAuth(tokenSHA256Request, USER, route):

    passSHA256 = sha256(PASS.encode('utf-8')).hexdigest()
    minutes = datetime.now().minute

    tokenString = USER + route + passSHA256 + str(minutes)
    tokenSHA256 = sha256(tokenString.encode('utf-8')).hexdigest()

    print(tokenSHA256Request)
    print(tokenSHA256)

    if tokenSHA256 == tokenSHA256Request:
        print('acceso correcto')
        return True
    else:
        print('acceso denegado')
        return False

@app.route('/images', methods=['POST','PUT','DELETE','GET'])
def images():
    print(request.json)
    response = ResponseModel()
    tokenSHA256Request = request.authorization['password']
    user = request.authorization['username']
    route = request.json['route']

    if checkTokenAuth(tokenSHA256Request, user, route):
        try:
            if request.method == 'POST':
                response = addImage(request.json['data'])
            elif request.method == 'GET':
                response = getImages(request.json['data'])
                #response = getStudent(request.json['data'])
            elif request.method == 'PUT':
                pass
                #response = updateStudent(request.json['data'])
            elif request.method == 'DELETE':
                pass
                #response = deleteStudent(request.json['data'])


        except Exception as e:
            print(e)
    else:
        response.data = 'NO TIENES ACCESO'

    return json.dumps(response.__dict__)

def addImage(image):
    response = DBHandler().insertarImagen(image)
    return response

def getImages(_idE):
    response = DBHandler().obtenerImagenes(_idE)
    return response






@app.route('/proovedores', methods=['POST','PUT','DELETE','GET'])
def students():
    print(request.json)
    response = ResponseModel()
    tokenSHA256Request = request.authorization['password']
    user = request.authorization['username']
    route = request.json['route']

    if checkTokenAuth(tokenSHA256Request, user, route):
        try:
            if request.method == 'POST':
                response = addSupplier(request.json['data'])
            elif request.method == 'GET':
                response = getSupplier(request.json['data'])
            elif request.method == 'PUT':
                response = updateSupplier(request.json['data'])
            elif request.method == 'DELETE':
                response = deleteSupplier(request.json['data'])


        except Exception as e:
            print(e)
    else:
        response.data = 'NO TIENES ACCESO'

    return json.dumps(response.__dict__)


def deleteSupplier(_idS):
    response = DBHandler().eliminarProveedor(_idS)
    return response


def updateSupplier(proveedor):
    response = DBHandler().actualizarProveedor(proveedor)
    return response

def getSupplier(_idS):
    if _idS == 'all':
        response = DBHandler().obtenerProveedores()
    else:
        response = DBHandler().obtenerProveedor(_idS)

    return response

def addSupplier(proveedor):
    response = DBHandler().insertarProveedor(proveedor)
    return response





if __name__ == '__main__':
    app.run(debug=True, port=5000, host='localhost')