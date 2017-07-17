/*
Navicat SQLite Data Transfer

Source Server         : SQLite
Source Server Version : 30706
Source Host           : :0

Target Server Type    : SQLite
Target Server Version : 30706
File Encoding         : 65001

Date: 2013-01-25 15:49:32
*/

PRAGMA foreign_keys = OFF;

-- ----------------------------
-- Table structure for "main"."GrainManageLog"
-- ----------------------------
DROP TABLE "main"."GrainManageLog";
CREATE TABLE "GrainManageLog" (
"ID"  INTEGER PRIMARY KEY AUTOINCREMENT,
"LogLevel"  TEXT,
"Message"  TEXT,
"Location"  TEXT,
"Exception"  TEXT,
"RunTime"  INTEGER,
"LogDate"  TEXT
);

-- ----------------------------
-- Records of GrainManageLog
-- ----------------------------
INSERT INTO "main"."GrainManageLog" VALUES (1, 'ERROR', 'Attempted to divide by zero.', 'GrainManage.Web.Controllers.BaseController.WriteLog(e:\GrainManage_NET45\MVC4\GrainManage.Web\Controllers\BaseController.cs:81)', 'System.DivideByZeroException: Attempted to divide by zero.
   at GrainManage.Web.Controllers.AccountController.Login(String targetName) in e:\GrainManage_NET45\MVC4\GrainManage.Web\Controllers\AccountController.cs:line 23
', 249, '2013-01-25 13:18:27.3604055');
INSERT INTO "main"."GrainManageLog" VALUES (2, 'ERROR', 'Attempted to divide by zero.', 'GrainManage.Web.Controllers.BaseController.WriteLog(e:\GrainManage_NET45\MVC4\GrainManage.Web\Controllers\BaseController.cs:81)', 'System.DivideByZeroException: Attempted to divide by zero.
   at GrainManage.Web.Controllers.AccountController.Login(String targetName) in e:\GrainManage_NET45\MVC4\GrainManage.Web\Controllers\AccountController.cs:line 23
', 234, '2013-01-25 13:22:43.2090895');
INSERT INTO "main"."GrainManageLog" VALUES (3, 'ERROR', 'Attempted to divide by zero.', 'GrainManage.Web.Controllers.BaseController.WriteLog(e:\GrainManage_NET45\MVC4\GrainManage.Web\Controllers\BaseController.cs:81)', 'System.DivideByZeroException: Attempted to divide by zero.
   at GrainManage.Web.Controllers.AccountController.Login(String targetName) in e:\GrainManage_NET45\MVC4\GrainManage.Web\Controllers\AccountController.cs:line 23
', 126126, '2013-01-25 13:24:49.1013106');
INSERT INTO "main"."GrainManageLog" VALUES (4, 'ERROR', 'Attempted to divide by zero.', 'GrainManage.Web.Controllers.BaseController.WriteLog(e:\GrainManage_NET45\MVC4\GrainManage.Web\Controllers\BaseController.cs:81)', 'System.DivideByZeroException: Attempted to divide by zero.
   at GrainManage.Web.Controllers.AccountController.Login(String targetName) in e:\GrainManage_NET45\MVC4\GrainManage.Web\Controllers\AccountController.cs:line 23
', 7452, '2013-01-25 13:25:38.3560036');
INSERT INTO "main"."GrainManageLog" VALUES (5, 'ERROR', 'Attempted to divide by zero.', 'GrainManage.Web.Controllers.BaseController.WriteLog(e:\GrainManage_NET45\MVC4\GrainManage.Web\Controllers\BaseController.cs:81)', 'System.DivideByZeroException: Attempted to divide by zero.
   at GrainManage.Web.Controllers.AccountController.Login(String targetName) in e:\GrainManage_NET45\MVC4\GrainManage.Web\Controllers\AccountController.cs:line 23
', 81805, '2013-01-25 13:26:52.7091612');
INSERT INTO "main"."GrainManageLog" VALUES (6, 'ERROR', 'Attempted to divide by zero.', 'GrainManage.Web.Controllers.BaseController.WriteLog(e:\GrainManage_NET45\MVC4\GrainManage.Web\Controllers\BaseController.cs:81)', 'System.DivideByZeroException: Attempted to divide by zero.
   at GrainManage.Web.Controllers.AccountController.Login(String targetName) in e:\GrainManage_NET45\MVC4\GrainManage.Web\Controllers\AccountController.cs:line 23
', 136873, '2013-01-25 13:27:47.7772579');
INSERT INTO "main"."GrainManageLog" VALUES (7, 'ERROR', 'Attempted to divide by zero.', 'GrainManage.Web.Controllers.BaseController.WriteLog(e:\GrainManage_NET45\MVC4\GrainManage.Web\Controllers\BaseController.cs:81)', 'System.DivideByZeroException: Attempted to divide by zero.
   at GrainManage.Web.Controllers.AccountController.Login(String targetName) in e:\GrainManage_NET45\MVC4\GrainManage.Web\Controllers\AccountController.cs:line 23
', 207780, '2013-01-25 13:28:58.6841823');
INSERT INTO "main"."GrainManageLog" VALUES (8, 'ERROR', 'Attempted to divide by zero.', 'GrainManage.Web.Controllers.BaseController.WriteLog(e:\GrainManage_NET45\MVC4\GrainManage.Web\Controllers\BaseController.cs:81)', 'System.DivideByZeroException: Attempted to divide by zero.
   at GrainManage.Web.Controllers.AccountController.Login(String targetName) in e:\GrainManage_NET45\MVC4\GrainManage.Web\Controllers\AccountController.cs:line 23
', 269182, '2013-01-25 13:30:00.0858902');
INSERT INTO "main"."GrainManageLog" VALUES (9, 'ERROR', 'Attempted to divide by zero.', 'GrainManage.Web.Controllers.BaseController.WriteLog(e:\GrainManage_NET45\MVC4\GrainManage.Web\Controllers\BaseController.cs:81)', 'System.DivideByZeroException: Attempted to divide by zero.
   at GrainManage.Web.Controllers.AccountController.Login(String targetName) in e:\GrainManage_NET45\MVC4\GrainManage.Web\Controllers\AccountController.cs:line 23
', 270399, '2013-01-25 13:30:01.3026923');
