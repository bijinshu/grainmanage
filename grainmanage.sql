/*
Navicat MySQL Data Transfer

Source Server         : localhost
Source Server Version : 50709
Source Host           : localhost:3306
Source Database       : grainmanage

Target Server Type    : MYSQL
Target Server Version : 50709
File Encoding         : 65001

Date: 2018-03-27 20:21:07
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for `bm_company`
-- ----------------------------
DROP TABLE IF EXISTS `bm_company`;
CREATE TABLE `bm_company` (
  `Id` int(11) NOT NULL AUTO_INCREMENT COMMENT '公司编号',
  `UserId` int(11) NOT NULL COMMENT '用户编号',
  `Name` varchar(60) NOT NULL DEFAULT '' COMMENT '公司名称',
  `Address` varchar(200) NOT NULL DEFAULT '' COMMENT '公司地址',
  `ImgName` varchar(60) NOT NULL DEFAULT '' COMMENT '图片名称',
  `Logo` varchar(60) NOT NULL DEFAULT '' COMMENT '缩略图',
  `CreatedAt` datetime NOT NULL COMMENT '创建时间',
  `ModifiedAt` datetime DEFAULT NULL COMMENT '修改时间',
  PRIMARY KEY (`Id`),
  UNIQUE KEY `uq_userid` (`UserId`) USING BTREE
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of bm_company
-- ----------------------------
INSERT INTO `bm_company` VALUES ('1', '1', '粮食收购中心', '北京市中南海', 'a081c5bccc318b3c1e41891274563af5.jpg', 'a081c5bccc318b3c1e41891274563af5.jpg', '2018-03-06 15:05:35', '2018-03-20 16:02:45');
INSERT INTO `bm_company` VALUES ('9', '2', '八集粮食收购门市', '泗阳县八集街', 'a081c5bccc318b3c1e41891274563af5.jpg', 'a081c5bccc318b3c1e41891274563af5.jpg', '2018-03-19 21:24:24', null);
INSERT INTO `bm_company` VALUES ('10', '19', '测试店铺', '测试中心', 'a081c5bccc318b3c1e41891274563af5.jpg', 'a081c5bccc318b3c1e41891274563af5.jpg', '2018-03-19 21:53:59', null);

-- ----------------------------
-- Table structure for `bm_contact`
-- ----------------------------
DROP TABLE IF EXISTS `bm_contact`;
CREATE TABLE `bm_contact` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `CompId` smallint(6) NOT NULL DEFAULT '0' COMMENT '公司编号',
  `ContactName` varchar(40) NOT NULL COMMENT '客户名称',
  `Mobile` char(11) NOT NULL DEFAULT '' COMMENT '手机',
  `Weixin` varchar(60) NOT NULL DEFAULT '' COMMENT '微信号',
  `QQ` varchar(20) NOT NULL DEFAULT '' COMMENT 'QQ',
  `Email` varchar(64) NOT NULL DEFAULT '' COMMENT '邮箱',
  `Address` varchar(100) NOT NULL DEFAULT '' COMMENT '地址',
  `ImgName` varchar(60) NOT NULL DEFAULT '' COMMENT '图片名称',
  `Remark` varchar(600) NOT NULL DEFAULT '' COMMENT '附加描述',
  `CreatedBy` int(11) NOT NULL COMMENT '创建者',
  `CreatedAt` datetime NOT NULL COMMENT '创建时间',
  `ModifiedAt` datetime DEFAULT NULL COMMENT '修改时间',
  PRIMARY KEY (`Id`),
  UNIQUE KEY `ContactName` (`ContactName`,`Mobile`,`CompId`) USING BTREE
) ENGINE=InnoDB AUTO_INCREMENT=31 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of bm_contact
-- ----------------------------
INSERT INTO `bm_contact` VALUES ('1', '1', '张海川', '15801992799', '', '914023961', 'bijinshu@163.com', '江苏省南京市雨花台区花神大道', '', '', '1', '2016-01-05 18:44:49', '2018-03-02 10:10:42');
INSERT INTO `bm_contact` VALUES ('2', '1', '李玉飞', '15801992799', '', '914023961', 'bijinshu@163.com', '江苏省南京市雨花台区软件大道119号', '', '', '1', '2016-01-05 18:44:49', '2018-01-04 20:10:47');
INSERT INTO `bm_contact` VALUES ('3', '1', '王亮亮', '15801992799', '', '914023961', 'bijinshu@163.com', '李祠堂', '', '', '1', '2016-01-05 18:44:49', '2017-07-21 17:07:42');
INSERT INTO `bm_contact` VALUES ('4', '1', '张思贤', '15801992799', '', '914023961', 'bijinshu@163.com', '六塘', '', '', '1', '2016-01-05 18:44:49', '2016-05-17 18:01:29');
INSERT INTO `bm_contact` VALUES ('5', '1', '刘江', '15801992799', '', '914023961', 'bijinshu@163.com', '泓北', '', '', '1', '2016-01-05 18:44:49', '2017-07-21 16:36:18');
INSERT INTO `bm_contact` VALUES ('6', '1', '鲍菲菲', '15801992799', '', '914023961', 'bijinshu@163.com', '大石渡', '', '', '1', '2016-01-05 18:44:49', null);
INSERT INTO `bm_contact` VALUES ('7', '1', '成杰', '15801992799', '', '914023961', 'bijinshu@163.com', '芦东', '', '', '1', '2016-01-05 18:44:49', '2017-07-21 16:59:38');
INSERT INTO `bm_contact` VALUES ('8', '1', '陈千业', '15801992799', '', '914023961', 'bijinshu@163.com', '董荡', '', '', '1', '2016-01-05 18:44:49', '2016-04-05 17:28:26');
INSERT INTO `bm_contact` VALUES ('9', '1', '齐昊', '15801992799', '', '914023961', 'bijinshu@163.com', '朱圩', '', '', '1', '2016-01-05 18:44:49', null);
INSERT INTO `bm_contact` VALUES ('10', '1', '任思', '15801992799', '', '914023961', 'bijinshu@163.com', '刘庄', '', '', '1', '2016-01-05 18:44:49', null);
INSERT INTO `bm_contact` VALUES ('11', '1', '贾亮', '15801992799', '', '914023961', 'bijinshu@163.com', '张刘', '', '', '1', '2016-01-05 18:44:49', null);
INSERT INTO `bm_contact` VALUES ('12', '1', '何远', '15801992799', '', '914023961', 'bijinshu@163.com', '育红', '', '', '1', '2016-01-05 18:44:49', null);
INSERT INTO `bm_contact` VALUES ('13', '1', '文一毫', '15801992799', '', '914023961', 'bijinshu@163.com', '河东', '', '', '1', '2016-01-05 18:44:49', null);
INSERT INTO `bm_contact` VALUES ('14', '1', '鲁云', '15801992799', '', '914023961', 'bijinshu@163.com', '桥西', '', '', '1', '2016-01-05 18:44:49', null);
INSERT INTO `bm_contact` VALUES ('15', '1', '毛强国', '15801992799', '', '914023961', 'bijinshu@163.com', '桥南', '', '', '1', '2016-01-05 18:44:49', null);
INSERT INTO `bm_contact` VALUES ('16', '1', '陈桥锋', '15801992799', '', '914023961', 'bijinshu@163.com', '合兴', '', '', '1', '2016-01-05 18:44:49', null);
INSERT INTO `bm_contact` VALUES ('17', '1', '秦汉', '15801992799', '', '914023961', 'bijinshu@163.com', '葛郑', '', '', '1', '2016-01-05 18:44:49', null);
INSERT INTO `bm_contact` VALUES ('18', '1', '李双江', '15801992799', '', '914023961', 'bijinshu@163.com', '倪荡', '', '', '1', '2016-01-05 18:44:49', null);
INSERT INTO `bm_contact` VALUES ('19', '1', '贝乐石', '15801992799', '', '914023961', 'bijinshu@163.com', '马洼', '', '', '1', '2016-01-05 18:44:49', null);
INSERT INTO `bm_contact` VALUES ('20', '1', '关楚生', '15801992799', '', '914023961', 'bijinshu@163.com', '葛荡', '', '', '1', '2016-01-05 18:44:49', null);
INSERT INTO `bm_contact` VALUES ('21', '1', '楚博雄', '15801992799', '', '914023961', 'bijinshu@163.com', '八集农科', '', '', '1', '2016-01-05 18:44:49', null);
INSERT INTO `bm_contact` VALUES ('22', '1', '张一凡', '15801992799', '', '914023961', 'bijinshu@163.com', '八集', '', '', '1', '2016-01-05 18:44:49', null);
INSERT INTO `bm_contact` VALUES ('23', '1', '刘玉生', '15801992799', '', '914023961', 'bijinshu@163.com', '桥西', '', '', '1', '2016-01-05 18:44:49', null);
INSERT INTO `bm_contact` VALUES ('24', '1', '吴雪奇', '15801992799', '', '914023961', 'bijinshu@163.com', '桥南', '', '', '1', '2016-01-05 18:44:49', null);
INSERT INTO `bm_contact` VALUES ('25', '1', '赵海', '15801992799', '', '914023961', 'bijinshu@163.com', '合兴', '', '', '1', '2016-01-05 18:44:49', null);
INSERT INTO `bm_contact` VALUES ('26', '1', '江涛', '15801992799', '', '914023961', 'bijinshu@163.com', '合兴', '', '', '1', '2016-01-05 18:44:49', null);
INSERT INTO `bm_contact` VALUES ('27', '1', '萧见浪', '15801992799', '', '914023961', 'bijinshu@163.com', '合兴', '', '', '1', '2016-01-05 18:44:49', null);
INSERT INTO `bm_contact` VALUES ('28', '1', '殷了', '15801992799', '', '914023961', 'bijinshu@163.com', '合兴', '', '', '1', '2016-01-05 18:44:49', null);
INSERT INTO `bm_contact` VALUES ('29', '1', '薛子琼', '15801992799', '', '914023961', 'bijinshu@163.com', '桥西', '', '', '1', '2016-01-05 18:44:49', null);
INSERT INTO `bm_contact` VALUES ('30', '1', '姚青', '15689547841', '', '', '', '江苏省南京市雨花台区花神大道', '', '', '2', '2018-03-18 11:20:05', null);

-- ----------------------------
-- Table structure for `bm_order`
-- ----------------------------
DROP TABLE IF EXISTS `bm_order`;
CREATE TABLE `bm_order` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Mobile` varchar(11) NOT NULL COMMENT '手机号码',
  `Address` varchar(200) NOT NULL DEFAULT '' COMMENT '地址',
  `CompId` int(11) NOT NULL DEFAULT '0' COMMENT '店铺编号',
  `CompName` varchar(60) NOT NULL DEFAULT '' COMMENT '店铺名称',
  `TotalMoney` decimal(20,2) NOT NULL COMMENT '计算总金额',
  `ActualMoney` decimal(20,2) NOT NULL COMMENT '实际成交金额',
  `Remark` varchar(600) NOT NULL DEFAULT '' COMMENT '备注',
  `Status` smallint(6) NOT NULL DEFAULT '0' COMMENT '0:待发送 1:待接单 2:已接单 3:交易成功 4:已取消 5:拒绝接单',
  `CreatedBy` int(11) NOT NULL DEFAULT '0' COMMENT '创建者',
  `CreatedAt` datetime NOT NULL COMMENT '创建时间',
  `ModifiedAt` datetime DEFAULT NULL COMMENT '修改时间',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of bm_order
-- ----------------------------
INSERT INTO `bm_order` VALUES ('1', '15801992799', '八集', '6', '泗阳粮食收购总代理', '832.00', '832.00', '', '3', '1', '2018-03-14 13:46:37', '2018-03-15 18:24:59');
INSERT INTO `bm_order` VALUES ('2', '15801992799', '八集', '6', '泗阳粮食收购总代理', '729.00', '729.00', '', '3', '1', '2018-03-14 15:39:08', '2018-03-15 17:37:58');
INSERT INTO `bm_order` VALUES ('3', '15801992799', '历史地看', '1', '八集粮食收购', '489.00', '0.00', '快点来', '5', '2', '2018-03-16 10:38:37', '2018-03-16 16:06:01');
INSERT INTO `bm_order` VALUES ('5', '15801992799', '胜多负少', '1', '八集粮食收购', '936.00', '832.00', '松岛枫', '3', '2', '2018-03-16 10:51:22', '2018-03-19 20:52:33');
INSERT INTO `bm_order` VALUES ('6', '15801992799', '', '1', '粮食收购中心', '4916.00', '0.00', '', '1', '2', '2018-03-22 14:22:55', null);

-- ----------------------------
-- Table structure for `bm_order_detail`
-- ----------------------------
DROP TABLE IF EXISTS `bm_order_detail`;
CREATE TABLE `bm_order_detail` (
  `Id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `OrderId` int(10) unsigned NOT NULL COMMENT '订单编号',
  `ProductId` int(11) NOT NULL COMMENT '产品编号',
  `ProductName` varchar(20) NOT NULL DEFAULT '' COMMENT '产品名称',
  `Price` decimal(20,4) NOT NULL COMMENT '价格',
  `Weight` decimal(20,2) NOT NULL COMMENT '重量',
  `TotalMoney` decimal(20,2) NOT NULL COMMENT '总价',
  `ActualPrice` decimal(20,4) NOT NULL COMMENT '实际价格',
  `ActualWeight` decimal(20,2) NOT NULL COMMENT '实际重量',
  `ActualMoney` decimal(20,2) NOT NULL COMMENT '实际金额',
  `CreatedBy` int(10) unsigned NOT NULL COMMENT '创建者',
  `CreatedAt` datetime NOT NULL COMMENT '创建时间',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of bm_order_detail
-- ----------------------------
INSERT INTO `bm_order_detail` VALUES ('1', '1', '9', '小麦', '1.0400', '500.00', '520.00', '1.0400', '800.00', '832.00', '1', '2018-03-14 13:46:37');
INSERT INTO `bm_order_detail` VALUES ('2', '2', '23', '玉米', '1.2050', '600.00', '723.00', '1.2050', '600.00', '729.00', '1', '2018-03-14 15:39:08');
INSERT INTO `bm_order_detail` VALUES ('3', '3', '25', '花生', '2.4450', '200.00', '489.00', '0.0000', '0.00', '0.00', '2', '2018-03-16 10:38:37');
INSERT INTO `bm_order_detail` VALUES ('7', '5', '9', '小麦', '1.0400', '900.00', '936.00', '1.0400', '800.00', '832.00', '2', '2018-03-16 10:51:22');
INSERT INTO `bm_order_detail` VALUES ('8', '6', '24', '菜籽', '2.2450', '800.00', '1796.00', '0.0000', '0.00', '0.00', '2', '2018-03-22 14:22:55');
INSERT INTO `bm_order_detail` VALUES ('9', '6', '9', '小麦', '1.0400', '3000.00', '3120.00', '0.0000', '0.00', '0.00', '2', '2018-03-22 14:22:55');

-- ----------------------------
-- Table structure for `bm_product`
-- ----------------------------
DROP TABLE IF EXISTS `bm_product`;
CREATE TABLE `bm_product` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(20) NOT NULL COMMENT '产品名称',
  `CompId` int(11) NOT NULL COMMENT '店铺Id',
  `CompName` varchar(60) NOT NULL DEFAULT '' COMMENT '店铺名称',
  `Price` decimal(20,4) NOT NULL COMMENT '价格',
  `Remark` varchar(600) NOT NULL DEFAULT '' COMMENT '备注',
  `Status` smallint(6) NOT NULL DEFAULT '0' COMMENT '0：离线 1：在线',
  `Source` smallint(6) NOT NULL COMMENT '来源/归属( 0：店铺产品 1：系统产品)',
  `CreatedAt` datetime NOT NULL COMMENT '创建时间',
  `CreatedBy` int(11) NOT NULL COMMENT '创建者',
  `ModifiedAt` datetime DEFAULT NULL COMMENT '修改时间',
  `ModifiedBy` int(11) DEFAULT NULL COMMENT '修改人',
  PRIMARY KEY (`Id`),
  UNIQUE KEY `uq_name` (`Name`,`CompId`,`Source`) USING BTREE
) ENGINE=InnoDB AUTO_INCREMENT=33 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of bm_product
-- ----------------------------
INSERT INTO `bm_product` VALUES ('1', '小麦', '0', '', '1.0400', '', '1', '1', '2017-08-30 00:00:00', '1', null, null);
INSERT INTO `bm_product` VALUES ('2', '黄豆', '0', '', '1.3000', '', '1', '1', '2017-08-30 00:00:00', '1', null, null);
INSERT INTO `bm_product` VALUES ('3', '大稻', '0', '', '1.2600', '', '1', '1', '2017-08-30 00:00:00', '1', null, null);
INSERT INTO `bm_product` VALUES ('4', '燕麦', '0', '', '1.3000', '', '1', '1', '2017-08-30 00:00:00', '1', null, null);
INSERT INTO `bm_product` VALUES ('5', '玉米', '0', '', '1.2050', '', '1', '1', '2017-08-30 00:00:00', '1', null, null);
INSERT INTO `bm_product` VALUES ('6', '花生', '0', '', '2.4450', '', '1', '1', '2017-08-30 00:00:00', '1', null, null);
INSERT INTO `bm_product` VALUES ('7', '菜籽', '0', '', '2.2450', '', '1', '1', '2017-08-30 00:00:00', '1', null, null);
INSERT INTO `bm_product` VALUES ('8', '小稻', '0', '', '1.2250', '', '1', '1', '2018-02-13 15:17:04', '1', '2018-03-01 17:27:25', '1');
INSERT INTO `bm_product` VALUES ('9', '小麦', '1', '八集粮食收购', '1.0400', '', '1', '0', '2018-03-07 13:07:13', '1', '2018-03-16 15:26:32', '1');
INSERT INTO `bm_product` VALUES ('21', '大稻', '1', '八集粮食收购', '1.2600', '', '1', '0', '2018-03-07 14:47:51', '1', '2018-03-16 15:26:28', '1');
INSERT INTO `bm_product` VALUES ('22', '小稻', '1', '八集粮食收购', '1.2250', '', '1', '0', '2018-03-07 14:48:01', '1', '2018-03-16 15:26:25', '1');
INSERT INTO `bm_product` VALUES ('23', '玉米', '6', '泗阳粮食收购总代理', '1.2050', '', '1', '0', '2018-03-07 14:48:47', '1', '2018-03-16 15:29:14', '2');
INSERT INTO `bm_product` VALUES ('24', '菜籽', '1', '八集粮食收购', '2.2450', '', '1', '0', '2018-03-13 19:32:29', '1', '2018-03-16 15:26:02', '1');
INSERT INTO `bm_product` VALUES ('25', '花生', '1', '八集粮食收购', '2.4450', '', '1', '0', '2018-03-13 19:32:33', '1', '2018-03-16 15:25:54', '1');
INSERT INTO `bm_product` VALUES ('26', '玉米', '1', '八集粮食收购', '1.2050', '', '1', '0', '2018-03-13 19:32:38', '1', '2018-03-16 15:25:50', '1');
INSERT INTO `bm_product` VALUES ('27', '玉米', '9', '八集粮食收购门市', '1.2050', '', '1', '0', '2018-03-19 21:41:48', '2', null, null);
INSERT INTO `bm_product` VALUES ('28', '大稻', '9', '八集粮食收购门市', '1.2600', '', '1', '0', '2018-03-19 21:41:53', '2', null, null);
INSERT INTO `bm_product` VALUES ('29', '小麦', '9', '八集粮食收购门市', '1.0400', '', '1', '0', '2018-03-19 21:41:58', '2', null, null);
INSERT INTO `bm_product` VALUES ('30', '小稻', '10', '测试店铺', '1.2250', '', '1', '0', '2018-03-19 21:54:49', '19', null, null);
INSERT INTO `bm_product` VALUES ('31', '菜籽', '10', '测试店铺', '2.2450', '', '1', '0', '2018-03-19 21:54:54', '19', null, null);
INSERT INTO `bm_product` VALUES ('32', '燕麦', '10', '测试店铺', '1.3000', '', '1', '0', '2018-03-19 21:54:59', '19', null, null);

-- ----------------------------
-- Table structure for `bm_trade`
-- ----------------------------
DROP TABLE IF EXISTS `bm_trade`;
CREATE TABLE `bm_trade` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `CompId` int(11) NOT NULL COMMENT '店铺Id',
  `ContactId` int(11) NOT NULL COMMENT '客户Id',
  `ContactName` varchar(20) NOT NULL DEFAULT '' COMMENT '联系人名称',
  `ActualMoney` decimal(20,2) NOT NULL DEFAULT '0.00' COMMENT '总成交金额',
  `TradeType` smallint(6) NOT NULL DEFAULT '0' COMMENT '0：收购: 1：出售',
  `Remark` varchar(6000) NOT NULL DEFAULT '' COMMENT '备注说明',
  `Status` smallint(6) NOT NULL COMMENT '0：等待合并 1：合并完成',
  `CreatedBy` int(11) NOT NULL COMMENT '创建者',
  `CreatedAt` datetime NOT NULL COMMENT '创建时间',
  `ModifiedAt` datetime DEFAULT NULL COMMENT '修改时间',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=69 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of bm_trade
-- ----------------------------
INSERT INTO `bm_trade` VALUES ('67', '1', '0', '', '1367.60', '0', '', '0', '1', '2018-03-27 17:39:44', '2018-03-27 17:49:22');
INSERT INTO `bm_trade` VALUES ('68', '1', '0', '', '1556.96', '0', '', '0', '1', '2018-03-27 18:21:30', null);

-- ----------------------------
-- Table structure for `bm_trade_detail`
-- ----------------------------
DROP TABLE IF EXISTS `bm_trade_detail`;
CREATE TABLE `bm_trade_detail` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `TradeId` int(11) NOT NULL COMMENT '交易编号',
  `ProductId` int(11) NOT NULL,
  `ProductName` varchar(20) NOT NULL DEFAULT '' COMMENT '产品名称',
  `Price` decimal(20,4) NOT NULL COMMENT '价格',
  `RoughWeight` decimal(20,2) NOT NULL COMMENT '毛重',
  `Tare` decimal(20,2) NOT NULL COMMENT '皮重',
  `ActualMoney` decimal(20,2) NOT NULL COMMENT '成交金额',
  `Remark` varchar(200) NOT NULL DEFAULT '' COMMENT '备注说明',
  `CreatedAt` datetime NOT NULL COMMENT '创建时间',
  `CreatedBy` int(11) NOT NULL COMMENT '创建人',
  `ModifiedAt` datetime DEFAULT NULL COMMENT '修改时间',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of bm_trade_detail
-- ----------------------------
INSERT INTO `bm_trade_detail` VALUES ('1', '66', '22', '小稻', '1.2250', '900.00', '1.00', '1101.28', '', '2018-03-23 18:34:19', '1', '2018-03-27 13:52:15');
INSERT INTO `bm_trade_detail` VALUES ('2', '66', '24', '菜籽', '2.2450', '600.00', '1.00', '1344.76', '', '2018-03-23 18:34:22', '1', '2018-03-27 13:52:15');
INSERT INTO `bm_trade_detail` VALUES ('3', '66', '22', '小稻', '1.2250', '1560.00', '1.00', '1909.78', '', '2018-03-27 13:44:31', '1', '2018-03-27 13:52:15');
INSERT INTO `bm_trade_detail` VALUES ('5', '67', '21', '大稻', '1.2600', '601.00', '2.00', '754.00', '', '2018-03-27 17:39:44', '1', '2018-03-27 17:49:22');
INSERT INTO `bm_trade_detail` VALUES ('6', '67', '9', '小麦', '1.0400', '600.00', '10.00', '613.00', '', '2018-03-27 17:39:44', '1', '2018-03-27 17:49:22');
INSERT INTO `bm_trade_detail` VALUES ('7', '68', '9', '小麦', '1.0400', '600.00', '1.00', '622.96', '', '2018-03-27 18:21:30', '1', null);
INSERT INTO `bm_trade_detail` VALUES ('8', '68', '9', '小麦', '1.0400', '900.00', '1.00', '934.00', '', '2018-03-27 18:21:30', '1', null);

-- ----------------------------
-- Table structure for `log_action`
-- ----------------------------
DROP TABLE IF EXISTS `log_action`;
CREATE TABLE `log_action` (
  `Id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `UserId` int(11) unsigned NOT NULL COMMENT '用户Id',
  `UserName` varchar(20) NOT NULL DEFAULT '' COMMENT '用户名称',
  `Path` varchar(200) NOT NULL DEFAULT '' COMMENT '动作名称',
  `ClientIP` varchar(64) NOT NULL DEFAULT '' COMMENT '访问端IP',
  `Method` varchar(6) NOT NULL DEFAULT '' COMMENT '请求方法',
  `Status` varchar(60) NOT NULL DEFAULT '' COMMENT '状态',
  `Para` text NOT NULL COMMENT '请求参数',
  `Level` smallint(6) NOT NULL COMMENT '级别',
  `StartTime` datetime NOT NULL COMMENT '调用开始时间',
  `EndTime` datetime DEFAULT NULL COMMENT '调用结束时间',
  `TimeSpan` time DEFAULT NULL COMMENT '耗时',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=29578 DEFAULT CHARSET=utf8 COMMENT='访问日志';

-- ----------------------------
-- Records of log_action
-- ----------------------------

-- ----------------------------
-- Table structure for `log_exception`
-- ----------------------------
DROP TABLE IF EXISTS `log_exception`;
CREATE TABLE `log_exception` (
  `Id` int(11) unsigned NOT NULL AUTO_INCREMENT,
  `Path` varchar(200) NOT NULL DEFAULT '' COMMENT '调用路径',
  `Para` text NOT NULL COMMENT '请求参数',
  `Message` varchar(600) NOT NULL DEFAULT '' COMMENT '描述',
  `StackTrace` text COMMENT '堆栈信息',
  `ClientIP` varchar(64) NOT NULL DEFAULT '' COMMENT '客户端调用IP',
  `CreatedAt` datetime NOT NULL COMMENT '创建时间',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=116 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of log_exception
-- ----------------------------

-- ----------------------------
-- Table structure for `log_job`
-- ----------------------------
DROP TABLE IF EXISTS `log_job`;
CREATE TABLE `log_job` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `JobName` varchar(20) NOT NULL COMMENT '任务名称',
  `Status` varchar(20) DEFAULT NULL COMMENT '状态',
  `Remark` varchar(600) DEFAULT NULL COMMENT '说明',
  `StartTime` datetime NOT NULL COMMENT '开始时间',
  `EndTime` datetime DEFAULT NULL COMMENT '结束时间',
  `TimeSpan` time DEFAULT NULL COMMENT '耗时',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of log_job
-- ----------------------------

-- ----------------------------
-- Table structure for `log_login`
-- ----------------------------
DROP TABLE IF EXISTS `log_login`;
CREATE TABLE `log_login` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `UserName` varchar(20) DEFAULT NULL COMMENT '用户名称',
  `LoginIP` varchar(64) DEFAULT NULL COMMENT '客户端登录IP',
  `Status` varchar(60) NOT NULL COMMENT '登录状态',
  `Level` smallint(6) NOT NULL COMMENT '级别-只有超过该级别的用户才可查看该条记录',
  `TypeId` smallint(6) NOT NULL DEFAULT '0' COMMENT '0：后台登录 1：微信端登录',
  `CreatedAt` datetime DEFAULT NULL COMMENT '创建时间',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=223 DEFAULT CHARSET=utf8 COMMENT='后台登录日志';

-- ----------------------------
-- Records of log_login
-- ----------------------------

-- ----------------------------
-- Table structure for `rm_address`
-- ----------------------------
DROP TABLE IF EXISTS `rm_address`;
CREATE TABLE `rm_address` (
  `Path` varchar(255) NOT NULL DEFAULT '' COMMENT '接口路径',
  `IsWatching` tinyint(6) NOT NULL COMMENT '0:不监控 1:监控 ',
  `IsValid` tinyint(6) NOT NULL COMMENT '0:无效地址 1:有效地址',
  `TypeId` smallint(6) NOT NULL COMMENT '0:受保护 1:免权限验证',
  `Remark` varchar(200) NOT NULL DEFAULT '' COMMENT '说明',
  `CreatedAt` datetime NOT NULL COMMENT '创建时间',
  `ModifiedAt` datetime DEFAULT NULL COMMENT '修改时间',
  PRIMARY KEY (`Path`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='地址监控配置表';

-- ----------------------------
-- Records of rm_address
-- ----------------------------
INSERT INTO `rm_address` VALUES ('/Address/Edit', '1', '1', '0', '', '2018-03-16 20:20:12', '2018-03-19 22:09:47');
INSERT INTO `rm_address` VALUES ('/Address/Index', '0', '1', '0', '', '2018-03-16 20:20:12', null);
INSERT INTO `rm_address` VALUES ('/Address/Refresh', '0', '0', '0', '', '2018-03-16 20:20:12', '2018-03-16 20:35:35');
INSERT INTO `rm_address` VALUES ('/Address/RefreshCache', '1', '1', '0', '', '2018-03-16 20:35:35', '2018-03-19 22:15:54');
INSERT INTO `rm_address` VALUES ('/Address/RefreshDb', '1', '1', '0', '', '2018-03-16 20:35:35', '2018-03-19 22:15:45');
INSERT INTO `rm_address` VALUES ('/Company/DeleteFile', '1', '1', '1', '删除店铺图片', '2018-03-09 17:37:16', '2018-03-19 22:08:28');
INSERT INTO `rm_address` VALUES ('/Company/Edit', '1', '1', '0', '编辑店铺信息', '2018-03-09 17:37:16', '2018-03-19 22:05:17');
INSERT INTO `rm_address` VALUES ('/Company/GetList', '0', '1', '1', '在店铺管理员注册好店铺信息并添加好产品信息后，此接口获取店铺信息并展示给普通用户', '2018-03-09 17:37:16', '2018-03-19 22:08:08');
INSERT INTO `rm_address` VALUES ('/Company/New', '1', '1', '1', '店铺管理员首次登录时，会创建一个店铺', '2018-03-09 17:37:16', '2018-03-19 22:05:05');
INSERT INTO `rm_address` VALUES ('/Contact/Delete', '1', '1', '0', '', '2018-02-11 16:43:27', null);
INSERT INTO `rm_address` VALUES ('/Contact/Edit', '1', '1', '0', '', '2018-02-11 16:43:27', null);
INSERT INTO `rm_address` VALUES ('/Contact/GetList', '0', '1', '1', '', '2018-03-09 17:37:16', null);
INSERT INTO `rm_address` VALUES ('/Contact/Index', '0', '1', '0', '', '2018-02-11 16:43:27', null);
INSERT INTO `rm_address` VALUES ('/Contact/New', '1', '1', '0', '', '2018-02-11 16:43:27', null);
INSERT INTO `rm_address` VALUES ('/Employee/Delete', '1', '1', '0', '删除店员', '2018-03-09 17:37:16', '2018-03-19 22:12:28');
INSERT INTO `rm_address` VALUES ('/Employee/Edit', '1', '1', '0', '', '2018-03-09 17:37:16', '2018-03-19 22:11:52');
INSERT INTO `rm_address` VALUES ('/Employee/Index', '0', '1', '0', '', '2018-03-09 17:37:16', null);
INSERT INTO `rm_address` VALUES ('/Employee/New', '1', '1', '0', '', '2018-03-09 17:37:16', '2018-03-19 22:11:32');
INSERT INTO `rm_address` VALUES ('/Home/Index', '0', '1', '1', '', '2018-02-11 16:43:23', null);
INSERT INTO `rm_address` VALUES ('/Home/MenuTree', '0', '1', '1', '', '2018-03-09 17:37:16', null);
INSERT INTO `rm_address` VALUES ('/Log/ActionList', '0', '1', '0', '', '2018-03-09 17:37:16', null);
INSERT INTO `rm_address` VALUES ('/Log/DeleteException', '1', '1', '0', '删除异常', '2018-03-09 17:37:16', '2018-03-19 22:12:42');
INSERT INTO `rm_address` VALUES ('/Log/ExceptionList', '0', '1', '0', '', '2018-03-09 17:37:16', null);
INSERT INTO `rm_address` VALUES ('/Log/JobList', '0', '1', '0', '', '2018-03-09 17:37:16', null);
INSERT INTO `rm_address` VALUES ('/Log/LoginList', '0', '1', '0', '', '2018-03-09 17:37:16', null);
INSERT INTO `rm_address` VALUES ('/Order/ChangeStatus', '1', '1', '0', '', '2018-03-16 20:20:12', '2018-03-19 22:10:09');
INSERT INTO `rm_address` VALUES ('/Order/Detail', '0', '1', '0', '', '2018-03-16 20:20:12', null);
INSERT INTO `rm_address` VALUES ('/Order/Edit', '1', '1', '0', '', '2018-03-16 20:20:12', '2018-03-19 22:09:40');
INSERT INTO `rm_address` VALUES ('/Order/GetPersonalOrder', '0', '1', '1', '', '2018-03-16 20:20:12', null);
INSERT INTO `rm_address` VALUES ('/Order/Index', '0', '1', '0', '', '2018-03-16 20:20:12', null);
INSERT INTO `rm_address` VALUES ('/Order/New', '1', '1', '1', '普通用户在商铺页面下单', '2018-03-16 20:20:12', '2018-03-19 22:11:01');
INSERT INTO `rm_address` VALUES ('/Product/Copy', '1', '1', '1', '', '2018-03-09 17:37:16', '2018-03-19 22:11:40');
INSERT INTO `rm_address` VALUES ('/Product/Delete', '1', '1', '0', '删除产品', '2018-03-09 17:37:16', '2018-03-19 22:12:13');
INSERT INTO `rm_address` VALUES ('/Product/Edit', '1', '1', '0', '', '2018-03-09 17:37:16', '2018-03-19 22:11:43');
INSERT INTO `rm_address` VALUES ('/Product/Index', '0', '1', '0', '', '2018-03-09 17:37:16', null);
INSERT INTO `rm_address` VALUES ('/Product/List', '0', '1', '1', '', '2018-03-09 17:37:16', null);
INSERT INTO `rm_address` VALUES ('/Product/New', '1', '1', '0', '', '2018-03-09 17:37:16', '2018-03-19 22:11:26');
INSERT INTO `rm_address` VALUES ('/Role/Delete', '1', '1', '0', '', '2018-02-11 16:43:27', null);
INSERT INTO `rm_address` VALUES ('/Role/Edit', '1', '1', '0', '', '2018-02-11 16:43:27', null);
INSERT INTO `rm_address` VALUES ('/Role/GetRoleList', '0', '1', '1', '', '2018-03-09 17:37:16', null);
INSERT INTO `rm_address` VALUES ('/Role/Index', '0', '1', '0', '', '2018-02-11 16:43:27', null);
INSERT INTO `rm_address` VALUES ('/Role/New', '1', '1', '0', '', '2018-02-11 16:43:27', null);
INSERT INTO `rm_address` VALUES ('/Trade/Delete', '1', '1', '0', '', '2018-03-09 17:37:16', '2018-03-19 22:11:48');
INSERT INTO `rm_address` VALUES ('/Trade/Edit', '1', '1', '0', '', '2018-03-09 17:37:16', '2018-03-19 22:11:18');
INSERT INTO `rm_address` VALUES ('/Trade/GetByContactId', '1', '1', '0', '获取某个客户的交易历史', '2018-03-09 17:37:16', '2018-03-20 15:41:07');
INSERT INTO `rm_address` VALUES ('/Trade/Index', '0', '1', '0', '', '2018-03-09 17:37:16', null);
INSERT INTO `rm_address` VALUES ('/Trade/New', '1', '1', '0', '创建新订单（既可以在我的客户页面调用，也可以在交易管理页面调用）', '2018-03-09 17:37:16', '2018-03-19 22:11:13');
INSERT INTO `rm_address` VALUES ('/User/ChangePwd', '1', '1', '1', '', '2018-02-11 16:43:27', null);
INSERT INTO `rm_address` VALUES ('/User/Delete', '1', '1', '0', '', '2018-02-11 16:43:27', null);
INSERT INTO `rm_address` VALUES ('/User/Edit', '1', '1', '0', '', '2018-02-11 16:43:27', null);
INSERT INTO `rm_address` VALUES ('/User/ForgetPwd', '1', '1', '0', '重置密码', '2018-03-19 22:14:39', '2018-03-19 22:15:35');
INSERT INTO `rm_address` VALUES ('/User/Index', '0', '1', '0', '', '2018-02-11 16:43:27', null);
INSERT INTO `rm_address` VALUES ('/User/Info', '0', '1', '1', '', '2018-02-11 16:43:27', null);
INSERT INTO `rm_address` VALUES ('/User/New', '1', '1', '0', '后台创建新用户', '2018-02-11 16:43:27', '2018-03-19 22:13:50');
INSERT INTO `rm_address` VALUES ('/User/Register', '1', '0', '0', '', '2018-02-11 16:43:27', '2018-03-19 22:14:39');
INSERT INTO `rm_address` VALUES ('/User/ResetPwd', '1', '0', '0', '', '2018-02-11 16:43:27', '2018-03-19 22:14:39');
INSERT INTO `rm_address` VALUES ('/User/SelfInfo', '0', '1', '1', '', '2018-03-21 18:05:19', null);
INSERT INTO `rm_address` VALUES ('/User/SignIn', '0', '1', '0', '', '2018-02-11 16:43:27', '2018-03-22 10:11:33');
INSERT INTO `rm_address` VALUES ('/User/SignOut', '1', '1', '1', '', '2018-02-11 16:43:27', null);
INSERT INTO `rm_address` VALUES ('/User/SignUp', '1', '1', '0', '新用户注册', '2018-03-19 22:14:39', '2018-03-20 20:16:49');
INSERT INTO `rm_address` VALUES ('/User/SimpleInfo', '0', '1', '1', '', '2018-03-16 20:20:12', null);
INSERT INTO `rm_address` VALUES ('/User/UpdateSelf', '0', '1', '1', '', '2018-03-21 18:05:19', null);
INSERT INTO `rm_address` VALUES ('/WhiteIp/Delete', '1', '1', '0', '', '2018-03-20 20:17:06', '2018-03-20 20:17:41');
INSERT INTO `rm_address` VALUES ('/WhiteIp/Edit', '1', '1', '0', '', '2018-03-20 20:17:06', '2018-03-20 20:17:34');
INSERT INTO `rm_address` VALUES ('/WhiteIp/Index', '0', '1', '0', '', '2018-03-20 20:17:06', null);
INSERT INTO `rm_address` VALUES ('/WhiteIp/New', '1', '1', '0', '', '2018-03-20 20:17:06', '2018-03-20 20:17:30');

-- ----------------------------
-- Table structure for `rm_role`
-- ----------------------------
DROP TABLE IF EXISTS `rm_role`;
CREATE TABLE `rm_role` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(20) NOT NULL COMMENT '角色名称',
  `Auths` varchar(1600) NOT NULL DEFAULT '' COMMENT '权限列表',
  `Level` smallint(6) NOT NULL COMMENT '级别',
  `Remark` varchar(600) NOT NULL DEFAULT '' COMMENT '备注',
  `CreatedAt` datetime NOT NULL COMMENT '创建时间',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8 COMMENT='系统角色，每个子系统都应该建立一个对应角色';

-- ----------------------------
-- Records of rm_role
-- ----------------------------
INSERT INTO `rm_role` VALUES ('1', '超级管理员', '', '100', '开发者专用用户', '2016-03-05 18:09:24');
INSERT INTO `rm_role` VALUES ('2', '普通用户', '', '80', '普通注册用户或关注公众号的用户', '2016-03-05 18:09:47');
INSERT INTO `rm_role` VALUES ('3', '店铺管理员', 'contact,contact.add,contact.delete,contact.edit,contact.trade,contact.view,employee,employee.add,employee.delete,employee.edit,employee.view,home,home.edit,order,order.add,order.approve,order.delete,order.detail,order.edit,order.view,product,product.add,product.copy,product.delete,product.edit,product.view,trade,trade.add,trade.delete,trade.edit,trade.view', '80', '管理店铺下的员工', '2017-07-19 18:27:34');
INSERT INTO `rm_role` VALUES ('4', '系统管理员', 'contact,contact.add,contact.delete,contact.edit,contact.trade,contact.view,employee,employee.add,employee.delete,employee.edit,employee.view,home,home.edit,log,log.action,log.action.view,log.exception,log.exception.delete,log.exception.view,log.job,log.job.view,log.login,log.login.view,order,order.add,order.approve,order.delete,order.detail,order.edit,order.view,product,product.add,product.copy,product.delete,product.edit,product.view,system,system.address,system.address.add,system.address.delete,system.address.edit,system.address.view,system.role,system.role.add,system.role.delete,system.role.edit,system.role.view,system.user,system.user.add,system.user.delete,system.user.edit,system.user.view,trade,trade.add,trade.delete,trade.edit,trade.view', '90', '管理系统用户', '2017-08-29 15:07:11');
INSERT INTO `rm_role` VALUES ('5', '店铺员工', 'contact,contact.add,contact.delete,contact.edit,contact.trade,contact.view,order,order.add,order.approve,order.detail,order.edit,order.view,product,product.add,product.copy,product.delete,product.edit,product.view,trade,trade.add,trade.delete,trade.edit,trade.view', '30', '店铺的员工，协助店铺管理员工作', '2018-02-26 11:31:05');

-- ----------------------------
-- Table structure for `rm_user`
-- ----------------------------
DROP TABLE IF EXISTS `rm_user`;
CREATE TABLE `rm_user` (
  `Id` int(32) NOT NULL AUTO_INCREMENT COMMENT '全局唯一编号',
  `UserName` varchar(20) NOT NULL DEFAULT '' COMMENT '用户名称、登录名称',
  `CompId` int(11) NOT NULL COMMENT '公司编号(-1:店铺管理员 需要完善店铺信息 0:普通用户)',
  `Pwd` varchar(42) NOT NULL DEFAULT '' COMMENT '密码',
  `Gender` smallint(6) NOT NULL DEFAULT '0' COMMENT '0:男 1:女',
  `Status` smallint(6) NOT NULL DEFAULT '0' COMMENT '0:禁用 1:启用',
  `RealName` varchar(20) NOT NULL DEFAULT '' COMMENT '真实姓名',
  `Mobile` char(11) NOT NULL DEFAULT '' COMMENT '手机号码',
  `Email` varchar(64) NOT NULL DEFAULT '' COMMENT '邮箱',
  `QQ` varchar(20) NOT NULL DEFAULT '' COMMENT 'QQ',
  `Weixin` varchar(20) NOT NULL DEFAULT '' COMMENT '微信',
  `Address` varchar(60) NOT NULL DEFAULT '' COMMENT '住址',
  `Roles` varchar(200) NOT NULL DEFAULT '' COMMENT '角色',
  `Remark` varchar(200) NOT NULL DEFAULT '' COMMENT '备注',
  `CreatedAt` datetime NOT NULL COMMENT '创建时间',
  `CreatedBy` int(11) NOT NULL COMMENT '创建者： -1:系统注册 >0 表内其它用户',
  `ModifiedAt` datetime DEFAULT NULL COMMENT '上次活动时间',
  PRIMARY KEY (`Id`),
  KEY `uq_user_name` (`UserName`) USING BTREE,
  KEY `index_mobile` (`Mobile`) USING BTREE
) ENGINE=InnoDB AUTO_INCREMENT=21 DEFAULT CHARSET=utf8 COMMENT='用户表';

-- ----------------------------
-- Records of rm_user
-- ----------------------------
INSERT INTO `rm_user` VALUES ('1', 'bijinshu', '1', 'a29f84d58cbbeae202d94673880d55d8ada19257', '0', '1', '毕金书', '15801992799', '914023961@qq.com', '914023961', 'bijinshu', '八集', '1', 'bijinshu', '2016-01-05 18:44:49', '0', '2018-03-22 16:20:07');
INSERT INTO `rm_user` VALUES ('2', 'bjc', '9', '69c5fcebaa65b560eaf06c3fbeb481ae44b8d618', '0', '1', '毕建昌', '15801992799', 'bijinshu@163.com', '12863589', 'bijinshu', '', '3', '555', '2016-01-05 18:44:49', '1', '2018-03-22 16:56:19');
INSERT INTO `rm_user` VALUES ('3', 'bj', '-1', '69c5fcebaa65b560eaf06c3fbeb481ae44b8d618', '1', '1', '毕娟', '15801992799', 'bijinshu@163.com', '96584258', '', '', '3', 'testroot', '2016-01-05 18:44:49', '1', '2018-03-19 15:08:05');
INSERT INTO `rm_user` VALUES ('15', 'bmx', '-1', '69c5fcebaa65b560eaf06c3fbeb481ae44b8d618', '0', '1', '毕明星', '15657476162', 'sdfd@xon.com', '95481563', 'bijinshusdlf', '', '3', '', '2018-03-02 10:12:34', '1', '2018-03-19 17:23:36');
INSERT INTO `rm_user` VALUES ('19', 'test', '10', '69c5fcebaa65b560eaf06c3fbeb481ae44b8d618', '0', '1', '', '15698751752', '', '', '', '', '3', '', '2018-03-19 21:47:08', '-1', '2018-03-21 17:40:47');
INSERT INTO `rm_user` VALUES ('20', 'bb', '0', '69c5fcebaa65b560eaf06c3fbeb481ae44b8d618', '0', '1', '', '15845751298', '', '', '', '', '2', '', '2018-03-23 10:12:08', '-1', '2018-03-23 10:12:08');

-- ----------------------------
-- Table structure for `rm_white_ip`
-- ----------------------------
DROP TABLE IF EXISTS `rm_white_ip`;
CREATE TABLE `rm_white_ip` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `IP` varchar(16) NOT NULL DEFAULT '' COMMENT 'IP',
  `Status` smallint(6) NOT NULL COMMENT '0：禁用 1：启用',
  `Remark` varchar(255) NOT NULL DEFAULT '' COMMENT '说明',
  `CreatedAt` datetime NOT NULL COMMENT '创建时间',
  `ModifiedAt` datetime DEFAULT NULL COMMENT '修改时间',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8 COMMENT='ip白名单';

-- ----------------------------
-- Records of rm_white_ip
-- ----------------------------
INSERT INTO `rm_white_ip` VALUES ('1', '10.10.133.108', '1', '', '2018-02-11 16:42:31', null);
INSERT INTO `rm_white_ip` VALUES ('2', '221.6.15.218', '1', '', '2018-03-20 11:25:02', null);
INSERT INTO `rm_white_ip` VALUES ('3', '172.16.232.255', '1', '', '2018-03-20 11:36:29', null);
