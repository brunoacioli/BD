import 'package:flutter/src/widgets/framework.dart';
import 'package:flutter/src/widgets/placeholder.dart';
import 'package:flutter/material.dart';
import 'package:sql_conn/sql_conn.dart';
import 'dart:async';

class Login extends StatefulWidget {
  const Login({super.key});

  @override
  State<Login> createState() => _LoginState();
}

class _LoginState extends State<Login> {

  Future<void> connect(BuildContext ctx) async {
  debugPrint("Connecting...");
  try {    
    showDialog(
        context: context,
        builder: (context) {
          return const AlertDialog(
            title: Text("LOADING"),
            content: CircularProgressIndicator(),
          );
        },
      );
    await SqlConn.connect(
        ip: "",
        port: "8101",
        databaseName: "p10g2",
        username: "p10g2",
        password: "Osmarfrango1");
    debugPrint("Connected!");
  } catch (e) {
    debugPrint(e.toString());
  } finally {
    Navigator.pop(ctx);
  }
}

  @override
  Widget build(BuildContext context) {
    return Center(
      child: ElevatedButton(
          onPressed: () => {connect(context)}, child: const Text("Connect")),
    );
  }
}

