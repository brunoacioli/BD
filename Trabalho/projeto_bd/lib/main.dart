import 'package:flutter/material.dart';
import 'package:sql_conn/sql_conn.dart';
import 'login.dart';
import 'dart:async';

void main() {
  // configurar barra de status do dispositivo para transparente  
  runApp(MaterialApp(
    initialRoute: '/',
    routes: {
      '/': (context) => const Login(),
    },
    debugShowCheckedModeBanner: false,
  ));
}

 