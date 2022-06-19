#include "BluetoothSerial.h"
#include <M5Stack.h>

BluetoothSerial SerialBT;

void setup() {
  // put your setup code here, to run once:
  Serial.begin(115200);
  SerialBT.begin("ESP32");
}

void loop() {
  // put your main code here, to run repeatedly:
  SerialBT.println("Hello World by BLE");
  delay(1000);
}
