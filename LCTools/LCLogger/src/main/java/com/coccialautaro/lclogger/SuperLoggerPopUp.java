package com.coccialautaro.lclogger;

import android.app.Activity;
import android.util.Log;
import android.app.AlertDialog;
import android.content.DialogInterface;
import android.view.WindowManager;


public class SuperLoggerPopUp {
    private static  final String TAG = "SuperLoggerPopUp";

    private SuperLoggerPopUp() {

    }

    public static SuperLoggerPopUp getInstance() {
        return SingletonHelper.INSTANCE;
    }
    public void ShowAlertWindow(Activity a, String msg){
        Log.i(TAG, "Showing alert ("+msg+")");

        AlertDialog d = new AlertDialog
                .Builder(a)
                .setTitle(msg)
                .setPositiveButton("PERMITIR", new DialogInterface.OnClickListener(){
                    public void onClick(DialogInterface dialog, int id) {
                        dialog.dismiss();
                    }
                })
                .setNegativeButton("RECHAZAR", new DialogInterface.OnClickListener() {
                    public void onClick(DialogInterface dialog, int id) {
                        dialog.dismiss();
                    }
                })
                .create();
        d.setCancelable(false);
        d.setCanceledOnTouchOutside(false);
        d.getWindow()
                .setFlags(WindowManager.LayoutParams.FLAG_NOT_FOCUSABLE, WindowManager.LayoutParams.FLAG_NOT_FOCUSABLE);
        d.show();
    }
    private static class SingletonHelper {
        private static final SuperLoggerPopUp INSTANCE = new SuperLoggerPopUp();
    }
}
