/*
Navicat SQLite Data Transfer

Source Server         : SQLite
Source Server Version : 30706
Source Host           : :0

Target Server Type    : SQLite
Target Server Version : 30706
File Encoding         : 65001

Date: 2013-01-25 15:49:46
*/

PRAGMA foreign_keys = OFF;

-- ----------------------------
-- Table structure for "main"."DetailLog"
-- ----------------------------
DROP TABLE "main"."DetailLog";
CREATE TABLE "DetailLog" (
"ID"  INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,
"AppDomain"  TEXT,
"UserName"  TEXT,
"Type"  TEXT,
"Level"  TEXT,
"Identity"  TEXT,
"Context"  TEXT,
"Request"  TEXT,
"Exception"  TEXT,
"File"  TEXT,
"Location"  TEXT,
"Line"  TEXT,
"Message"  TEXT,
"Method"  TEXT,
"Thread"  TEXT,
"CreateTime"  TEXT,
"RunTime"  TEXT,
"Logger"  TEXT,
"StackTrace"  TEXT,
"StackTraceDetail"  TEXT
);

-- ----------------------------
-- Records of DetailLog
-- ----------------------------
