/*
Navicat SQLite Data Transfer

Source Server         : SQLite
Source Server Version : 30706
Source Host           : :0

Target Server Type    : SQLite
Target Server Version : 30706
File Encoding         : 65001

Date: 2013-01-25 15:49:56
*/

PRAGMA foreign_keys = OFF;

-- ----------------------------
-- Table structure for "main"."DebugLog"
-- ----------------------------
DROP TABLE "main"."DebugLog";
CREATE TABLE "DebugLog" (
"ID"  INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,
"AppDomain"  TEXT,
"File"  TEXT,
"Identity"  TEXT,
"Location"  TEXT,
"Line"  TEXT,
"Method"  TEXT,
"Type"  TEXT,
"UserName"  TEXT
);

-- ----------------------------
-- Records of DebugLog
-- ----------------------------
