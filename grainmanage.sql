/*
Navicat MySQL Data Transfer

Source Server         : localhost
Source Server Version : 50709
Source Host           : localhost:3306
Source Database       : grainmanage

Target Server Type    : MYSQL
Target Server Version : 50709
File Encoding         : 65001

Date: 2018-02-13 16:08:35
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for `bm_contact`
-- ----------------------------
DROP TABLE IF EXISTS `bm_contact`;
CREATE TABLE `bm_contact` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `AppId` smallint(6) NOT NULL DEFAULT '0' COMMENT '应用编号',
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
  UNIQUE KEY `ContactName` (`ContactName`,`Mobile`,`AppId`) USING BTREE
) ENGINE=InnoDB AUTO_INCREMENT=30 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of bm_contact
-- ----------------------------
INSERT INTO `bm_contact` VALUES ('1', '1', '张海川', '15801992799', '', '914023961', 'bijinshu@163.com', '中国江苏省南京市雨花台区雨花南路4号-10号 邮政编码: 210012', '', '', '1', '2016-01-05 18:44:49', '2018-02-11 10:38:14');
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

-- ----------------------------
-- Table structure for `bm_order`
-- ----------------------------
DROP TABLE IF EXISTS `bm_order`;
CREATE TABLE `bm_order` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Mobile` varchar(11) NOT NULL COMMENT '手机号码',
  `Address` varchar(200) NOT NULL DEFAULT '' COMMENT '地址',
  `FromUserId` int(11) NOT NULL DEFAULT '0' COMMENT '发单用户编号',
  `ToUserId` int(11) NOT NULL DEFAULT '0' COMMENT '接单商户编号',
  `Remark` varchar(600) NOT NULL DEFAULT '' COMMENT '备注',
  `Status` smallint(6) NOT NULL DEFAULT '0' COMMENT '0:待发送 1:待接单 2:已接单 3:交易成功 4:交易失败',
  `CreatedAt` datetime NOT NULL COMMENT '创建时间',
  `AcceptedAt` datetime DEFAULT NULL COMMENT '接单时间',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of bm_order
-- ----------------------------

-- ----------------------------
-- Table structure for `bm_order_detail`
-- ----------------------------
DROP TABLE IF EXISTS `bm_order_detail`;
CREATE TABLE `bm_order_detail` (
  `Id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `OrderId` int(10) unsigned NOT NULL COMMENT '订单编号',
  `ProductId` int(11) NOT NULL COMMENT '产品编号',
  `Price` decimal(20,4) NOT NULL COMMENT '价格',
  `Num` decimal(20,2) NOT NULL COMMENT '数量',
  `Unit` smallint(6) NOT NULL COMMENT '单位',
  `TotalMoney` decimal(20,2) NOT NULL COMMENT '总价',
  `CreatedAt` datetime NOT NULL COMMENT '创建时间',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of bm_order_detail
-- ----------------------------

-- ----------------------------
-- Table structure for `bm_price`
-- ----------------------------
DROP TABLE IF EXISTS `bm_price`;
CREATE TABLE `bm_price` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Grain` varchar(40) NOT NULL DEFAULT '' COMMENT '作物名称',
  `Price` decimal(20,4) NOT NULL DEFAULT '0.0000' COMMENT '价格',
  `Unit` smallint(6) NOT NULL COMMENT '单位',
  `PriceType` varchar(20) NOT NULL DEFAULT '' COMMENT '收购、销售',
  `Remark` varchar(200) NOT NULL DEFAULT '' COMMENT '附加描述',
  `CreatedBy` int(11) NOT NULL COMMENT '创建者',
  `CreatedAt` datetime NOT NULL COMMENT '创建时间',
  `ModifiedAt` datetime DEFAULT NULL COMMENT '修改时间',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=27 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of bm_price
-- ----------------------------
INSERT INTO `bm_price` VALUES ('1', '玉米', '2.0100', '0', '销售', '元/千克', '1', '2007-10-12 08:40:22', null);
INSERT INTO `bm_price` VALUES ('2', '大稻', '2.5200', '0', '收购', '元/千克', '4', '2007-10-13 08:40:22', null);
INSERT INTO `bm_price` VALUES ('3', '小稻', '2.3300', '0', '销售', '元/千克', '1', '2007-10-14 08:40:22', null);
INSERT INTO `bm_price` VALUES ('4', '小麦', '2.0400', '0', '收购', '元/千克', '4', '2007-10-15 08:40:22', null);
INSERT INTO `bm_price` VALUES ('5', '菜籽', '3.6500', '0', '销售', '元/千克', '1', '2007-10-16 08:40:22', null);
INSERT INTO `bm_price` VALUES ('6', '花生', '3.0600', '0', '收购', '元/千克', '4', '2010-10-17 08:40:22', null);
INSERT INTO `bm_price` VALUES ('7', '大稻', '2.5200', '0', '收购', '元/千克', '1', '2012-10-13 08:40:22', null);
INSERT INTO `bm_price` VALUES ('8', '玉米', '2.3300', '0', '销售', '元/千克', '4', '2012-10-14 08:40:22', null);
INSERT INTO `bm_price` VALUES ('9', '玉米', '2.2900', '0', '销售', '元/千克', '1', '2007-10-18 08:40:22', null);
INSERT INTO `bm_price` VALUES ('10', '大稻', '2.6000', '0', '收购', '元/千克', '4', '2007-10-19 08:40:22', null);
INSERT INTO `bm_price` VALUES ('11', '小稻', '2.4200', '0', '销售', '元/千克', '1', '2007-10-20 08:40:22', null);
INSERT INTO `bm_price` VALUES ('12', '小麦', '2.1300', '0', '收购', '元/千克', '4', '2007-10-21 08:40:22', null);
INSERT INTO `bm_price` VALUES ('13', '菜籽', '3.7400', '0', '销售', '元/千克', '1', '2007-10-22 08:40:22', null);
INSERT INTO `bm_price` VALUES ('14', '花生', '3.1700', '0', '收购', '元/千克', '4', '2010-10-23 08:40:22', null);
INSERT INTO `bm_price` VALUES ('15', '玉米', '2.2200', '0', '收购', '元/千克', '1', '2008-12-24 08:40:22', null);
INSERT INTO `bm_price` VALUES ('16', '大稻', '2.7400', '0', '销售', '元/千克', '4', '2008-12-25 08:40:22', null);
INSERT INTO `bm_price` VALUES ('17', '小稻', '2.6600', '0', '销售', '元/千克', '1', '2008-12-26 08:40:22', null);
INSERT INTO `bm_price` VALUES ('18', '小麦', '2.0800', '0', '收购', '元/千克', '4', '2008-12-27 08:40:22', null);
INSERT INTO `bm_price` VALUES ('19', '菜籽', '3.4000', '0', '销售', '元/千克', '1', '2008-12-28 08:40:22', null);
INSERT INTO `bm_price` VALUES ('20', '花生', '2.6700', '0', '销售', '元/千克', '4', '2008-10-29 08:40:22', null);
INSERT INTO `bm_price` VALUES ('21', '玉米', '2.4100', '0', '收购', '元/千克', '1', '2009-02-01 08:40:22', null);
INSERT INTO `bm_price` VALUES ('22', '大稻', '2.8300', '0', '销售', '元/千克', '4', '2009-02-12 08:40:22', null);
INSERT INTO `bm_price` VALUES ('23', '小稻', '2.4500', '0', '收购', '元/千克', '1', '2009-02-13 08:40:22', null);
INSERT INTO `bm_price` VALUES ('24', '小麦', '2.0700', '0', '收购', '元/千克', '4', '2009-02-14 08:40:22', null);
INSERT INTO `bm_price` VALUES ('25', '菜籽', '4.4900', '0', '收购', '元/千克', '1', '2009-02-15 08:40:22', null);
INSERT INTO `bm_price` VALUES ('26', '花生', '4.8900', '0', '收购', '元/千克', '4', '2009-02-16 08:40:22', null);

-- ----------------------------
-- Table structure for `bm_product`
-- ----------------------------
DROP TABLE IF EXISTS `bm_product`;
CREATE TABLE `bm_product` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(20) NOT NULL COMMENT '产品名称',
  `Remark` varchar(600) NOT NULL DEFAULT '' COMMENT '备注',
  `Status` smallint(6) NOT NULL DEFAULT '0' COMMENT '0：离线 1：在线',
  `CreatedAt` datetime NOT NULL COMMENT '创建时间',
  `CreatedBy` int(11) NOT NULL COMMENT '创建者',
  `ModifiedAt` datetime DEFAULT NULL COMMENT '修改时间',
  `ModifiedBy` int(11) DEFAULT NULL COMMENT '修改人',
  PRIMARY KEY (`Id`),
  UNIQUE KEY `uq_name` (`Name`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of bm_product
-- ----------------------------
INSERT INTO `bm_product` VALUES ('1', '小麦', '', '1', '2017-08-30 00:00:00', '1', null, null);
INSERT INTO `bm_product` VALUES ('2', '收购', '', '1', '2017-08-30 00:00:00', '1', null, null);
INSERT INTO `bm_product` VALUES ('3', '大稻', '', '1', '2017-08-30 00:00:00', '1', null, null);
INSERT INTO `bm_product` VALUES ('4', '燕麦', '', '1', '2017-08-30 00:00:00', '1', null, null);
INSERT INTO `bm_product` VALUES ('5', '玉米', '', '1', '2017-08-30 00:00:00', '1', null, null);
INSERT INTO `bm_product` VALUES ('6', '花生', '', '1', '2017-08-30 00:00:00', '1', null, null);
INSERT INTO `bm_product` VALUES ('7', '菜籽', '', '1', '2017-08-30 00:00:00', '1', null, null);
INSERT INTO `bm_product` VALUES ('8', '小稻', '', '1', '2018-02-13 15:17:04', '1', null, null);

-- ----------------------------
-- Table structure for `bm_trade`
-- ----------------------------
DROP TABLE IF EXISTS `bm_trade`;
CREATE TABLE `bm_trade` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `ContactId` int(11) DEFAULT NULL COMMENT '客户Id',
  `ProductId` varchar(40) NOT NULL DEFAULT '' COMMENT '作物名称',
  `Price` decimal(20,4) NOT NULL DEFAULT '0.0000' COMMENT '计划价格',
  `Weight` decimal(20,2) DEFAULT '0.00' COMMENT '重量',
  `ActualMoney` decimal(20,2) DEFAULT '0.00' COMMENT '成交价格',
  `TradeType` smallint(6) NOT NULL DEFAULT '0' COMMENT '0：收购: 1：出售',
  `Position` varchar(60) DEFAULT NULL,
  `PositionDesc` varchar(80) DEFAULT NULL,
  `Remark` varchar(6000) DEFAULT '',
  `CreatedBy` int(11) DEFAULT NULL COMMENT '创建者',
  `CreatedAt` datetime DEFAULT NULL COMMENT '创建时间',
  `ModifiedAt` datetime DEFAULT NULL COMMENT '修改时间',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=39 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of bm_trade
-- ----------------------------
INSERT INTO `bm_trade` VALUES ('1', '1', '5', '2.2200', '306.00', '679.32', '0', null, null, '', '1', '2007-11-02 14:47:03', null);
INSERT INTO `bm_trade` VALUES ('2', '2', '3', '2.7400', '316.00', '865.84', '0', null, null, '', '4', '2012-11-02 14:47:03', null);
INSERT INTO `bm_trade` VALUES ('3', '3', '8', '2.6600', '306.00', '813.96', '1', null, null, '', '1', '2007-11-02 14:47:03', null);
INSERT INTO `bm_trade` VALUES ('4', '4', '1', '2.0800', '208.00', '432.64', '0', null, null, '', '4', '2007-11-02 14:47:03', null);
INSERT INTO `bm_trade` VALUES ('5', '5', '7', '3.4000', '306.00', '1040.40', '1', null, null, '', '1', '2007-11-02 14:47:03', null);
INSERT INTO `bm_trade` VALUES ('6', '6', '6', '2.6700', '306.00', '817.02', '0', null, null, '', '4', '2007-11-02 14:47:03', null);
INSERT INTO `bm_trade` VALUES ('7', '7', '5', '2.4100', '306.00', '737.46', '0', null, null, '', '1', '2007-11-02 14:47:03', null);
INSERT INTO `bm_trade` VALUES ('8', '8', '3', '2.8300', '306.00', '865.98', '1', null, null, '', '4', '2007-11-03 14:47:03', null);
INSERT INTO `bm_trade` VALUES ('9', '9', '8', '2.4500', '306.00', '749.70', '1', null, null, '', '1', '2009-11-04 15:47:03', null);
INSERT INTO `bm_trade` VALUES ('10', '10', '1', '2.0700', '306.00', '633.42', '1', null, null, '', '4', '2009-12-05 14:47:03', null);
INSERT INTO `bm_trade` VALUES ('11', '11', '7', '4.4900', '306.00', '1373.94', '1', null, null, '', '1', '2012-11-02 14:47:03', null);
INSERT INTO `bm_trade` VALUES ('12', '12', '6', '4.8900', '316.00', '1545.24', '0', null, null, '', '4', '2012-11-02 14:47:03', null);
INSERT INTO `bm_trade` VALUES ('13', '13', '5', '2.0100', '406.00', '816.06', '0', null, null, '', '1', '2007-11-02 14:47:03', null);
INSERT INTO `bm_trade` VALUES ('14', '14', '3', '2.5200', '306.00', '771.12', '1', null, null, '', '4', '2007-11-03 14:47:03', null);
INSERT INTO `bm_trade` VALUES ('15', '15', '8', '2.3300', '306.00', '712.98', '0', null, null, '', '1', '2009-11-04 15:47:03', null);
INSERT INTO `bm_trade` VALUES ('16', '16', '1', '2.0400', '306.00', '624.24', '1', null, null, '', '4', '2009-12-05 14:47:03', null);
INSERT INTO `bm_trade` VALUES ('17', '17', '7', '3.6500', '306.00', '1116.90', '1', null, null, '', '1', '2007-06-01 15:47:03', null);
INSERT INTO `bm_trade` VALUES ('18', '18', '6', '3.0600', '316.00', '966.96', '0', null, null, '', '4', '2006-08-02 14:22:00', null);
INSERT INTO `bm_trade` VALUES ('19', '19', '3', '2.5200', '306.00', '771.12', '0', null, null, '', '1', '2005-07-02 13:47:03', null);
INSERT INTO `bm_trade` VALUES ('20', '20', '5', '2.3300', '406.00', '945.98', '1', null, null, '', '4', '2004-09-02 08:47:03', null);
INSERT INTO `bm_trade` VALUES ('21', '21', '5', '2.2900', '306.00', '700.74', '0', null, null, '', '1', '2004-09-02 08:50:00', null);
INSERT INTO `bm_trade` VALUES ('22', '22', '3', '2.6000', '306.00', '795.60', '0', null, null, '', '4', '2006-01-02 09:47:56', null);
INSERT INTO `bm_trade` VALUES ('23', '23', '8', '2.4200', '306.00', '740.52', '0', null, null, '', '1', '2006-01-02 09:50:26', null);
INSERT INTO `bm_trade` VALUES ('24', '24', '1', '2.1300', '306.00', '651.78', '0', null, null, '', '4', '2010-11-03 10:00:00', null);
INSERT INTO `bm_trade` VALUES ('25', '1', '7', '3.7400', '306.00', '1144.44', '0', null, null, '', '1', '2010-08-04 18:45:43', null);
INSERT INTO `bm_trade` VALUES ('26', '1', '6', '3.1700', '306.00', '970.02', '0', null, null, '', '4', '2009-12-06 14:47:03', null);
INSERT INTO `bm_trade` VALUES ('27', '2', '5', '2.2200', '306.00', '679.32', '1', null, null, '', '1', '2007-11-02 10:40:03', null);
INSERT INTO `bm_trade` VALUES ('28', '2', '3', '2.7400', '316.00', '865.84', '1', null, null, '', '4', '2010-09-02 12:58:22', null);
INSERT INTO `bm_trade` VALUES ('29', '2', '8', '2.6600', '316.00', '840.56', '0', null, null, '', '1', '2010-05-02 08:42:27', null);
INSERT INTO `bm_trade` VALUES ('30', '20', '1', '2.0800', '306.00', '636.48', '1', null, null, '', '4', '2010-06-22 12:28:08', null);
INSERT INTO `bm_trade` VALUES ('31', '18', '7', '3.4000', '306.00', '1040.40', '1', null, null, '', '1', '2010-11-04 19:20:08', null);
INSERT INTO `bm_trade` VALUES ('32', '18', '6', '2.6700', '306.00', '817.02', '0', null, null, '', '4', '2010-12-05 16:36:09', null);
INSERT INTO `bm_trade` VALUES ('33', '16', '5', '2.4100', '306.00', '737.46', '1', null, null, '', '1', '2007-11-02 10:40:03', null);
INSERT INTO `bm_trade` VALUES ('34', '16', '3', '2.8300', '316.00', '894.28', '1', null, null, '', '4', '2006-09-02 12:58:22', null);
INSERT INTO `bm_trade` VALUES ('35', '7', '8', '2.4500', '406.00', '994.70', '0', null, null, '', '1', '2005-05-02 08:42:27', null);
INSERT INTO `bm_trade` VALUES ('36', '8', '1', '2.0700', '306.00', '633.42', '1', null, null, '', '4', '2007-06-22 12:28:08', null);
INSERT INTO `bm_trade` VALUES ('37', '15', '7', '4.4900', '306.00', '1373.94', '1', null, null, '', '1', '2006-11-04 19:20:08', null);
INSERT INTO `bm_trade` VALUES ('38', '9', '6', '4.8900', '306.00', '1496.34', '1', null, null, '', '4', '2009-12-05 16:36:09', null);

-- ----------------------------
-- Table structure for `log_action`
-- ----------------------------
DROP TABLE IF EXISTS `log_action`;
CREATE TABLE `log_action` (
  `Id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `UserName` varchar(20) NOT NULL DEFAULT '' COMMENT '用户Id',
  `Path` varchar(200) NOT NULL DEFAULT '' COMMENT '动作名称',
  `ClientIP` varchar(64) NOT NULL DEFAULT '' COMMENT '访问端IP',
  `Method` varchar(6) NOT NULL DEFAULT '' COMMENT '请求方法',
  `Status` varchar(60) NOT NULL DEFAULT '' COMMENT '状态',
  `Para` varchar(1200) NOT NULL DEFAULT '' COMMENT '请求参数',
  `Level` smallint(6) NOT NULL COMMENT '级别',
  `StartTime` datetime NOT NULL COMMENT '调用开始时间',
  `EndTime` datetime DEFAULT NULL COMMENT '调用结束时间',
  `TimeSpan` time DEFAULT NULL COMMENT '耗时',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=365 DEFAULT CHARSET=utf8 COMMENT='访问日志';

-- ----------------------------
-- Records of log_action
-- ----------------------------
INSERT INTO `log_action` VALUES ('49', 'bijinshu', '/Home/Index', '10.10.133.209', 'GET', '', '', '0', '2017-08-29 14:13:46', '2017-08-29 14:13:47', '00:00:01');
INSERT INTO `log_action` VALUES ('50', 'bijinshu', '/User/SignIn', '10.10.133.209', 'GET', '', '', '0', '2017-08-29 14:13:48', '2017-08-29 14:13:48', '00:00:00');
INSERT INTO `log_action` VALUES ('51', 'bijinshu', '/User/SignIn', '10.10.133.209', 'GET', '', '', '0', '2017-08-29 14:14:06', '2017-08-29 14:14:06', '00:00:00');
INSERT INTO `log_action` VALUES ('52', 'bijinshu', '/User/SignIn', '10.10.133.209', 'POST', '成功', '{\"UserName\":\"bijinshu\",\"Pwd\":\"40bd001563085fc35165329ea1ff5c5ecbdbbeef\"}', '0', '2017-08-29 14:14:07', '2017-08-29 14:14:09', '00:00:02');
INSERT INTO `log_action` VALUES ('53', 'bijinshu', '/Home/Index', '10.10.133.209', 'GET', '', '', '0', '2017-08-29 14:14:09', '2017-08-29 14:14:09', '00:00:01');
INSERT INTO `log_action` VALUES ('54', 'bijinshu', '/User/SignIn', '10.10.133.209', 'GET', '', '', '0', '2017-08-29 14:14:11', '2017-08-29 14:14:11', '00:00:01');
INSERT INTO `log_action` VALUES ('55', 'bijinshu', '/User/SignIn', '10.10.133.209', 'GET', '', '', '0', '2017-08-29 14:46:44', '2017-08-29 14:46:44', '00:00:00');
INSERT INTO `log_action` VALUES ('56', 'bijinshu', '/User/SignIn', '10.10.133.209', 'POST', '成功', '{\"UserName\":\"bijinshu\",\"Pwd\":\"40bd001563085fc35165329ea1ff5c5ecbdbbeef\"}', '0', '2017-08-29 14:46:46', '2017-08-29 14:46:48', '00:00:03');
INSERT INTO `log_action` VALUES ('57', 'bijinshu', '/Home/Index', '10.10.133.209', 'GET', '', '', '0', '2017-08-29 14:46:48', '2017-08-29 14:46:48', '00:00:01');
INSERT INTO `log_action` VALUES ('58', 'bijinshu', '/User/SignIn', '10.10.133.209', 'GET', '', '', '0', '2017-08-29 14:46:50', '2017-08-29 14:46:50', '00:00:01');
INSERT INTO `log_action` VALUES ('59', 'bijinshu', '/', '10.10.133.209', 'GET', '', '', '0', '2017-08-29 14:46:56', '2017-08-29 14:46:56', '00:00:01');
INSERT INTO `log_action` VALUES ('60', 'bijinshu', '/User/SignIn', '10.10.133.209', 'POST', '成功', '{\"UserName\":\"bijinshu\",\"Pwd\":\"40bd001563085fc35165329ea1ff5c5ecbdbbeef\"}', '0', '2017-08-29 14:47:20', '2017-08-29 14:47:21', '00:00:01');
INSERT INTO `log_action` VALUES ('61', 'bijinshu', '/Home/Index', '10.10.133.209', 'GET', '', '', '0', '2017-08-29 14:47:22', '2017-08-29 14:47:22', '00:00:01');
INSERT INTO `log_action` VALUES ('62', 'bijinshu', '/User/SignIn', '10.10.133.209', 'GET', '', '', '0', '2017-08-29 14:48:06', '2017-08-29 14:48:06', '00:00:01');
INSERT INTO `log_action` VALUES ('63', 'bijinshu', '/User/SignIn', '10.10.133.209', 'GET', '', '', '0', '2017-08-29 14:48:25', '2017-08-29 14:48:25', '00:00:00');
INSERT INTO `log_action` VALUES ('64', '', '/User/SignIn', '10.10.133.209', 'GET', '', '', '0', '2017-08-29 14:48:44', '2017-08-29 14:48:44', '00:00:01');
INSERT INTO `log_action` VALUES ('65', '', '/User/SignIn', '10.10.133.209', 'POST', '成功', '{\"UserName\":\"bijinshu\",\"Pwd\":\"40bd001563085fc35165329ea1ff5c5ecbdbbeef\"}', '0', '2017-08-29 14:48:48', '2017-08-29 14:48:48', '00:00:00');
INSERT INTO `log_action` VALUES ('66', 'bijinshu', '/Home/Index', '10.10.133.209', 'GET', '', '', '0', '2017-08-29 14:48:49', '2017-08-29 14:48:49', '00:00:00');
INSERT INTO `log_action` VALUES ('67', 'bijinshu', '/User/SignIn', '10.10.133.209', 'GET', '', '', '0', '2017-08-29 14:50:50', '2017-08-29 14:50:50', '00:00:00');
INSERT INTO `log_action` VALUES ('68', 'bijinshu', '/User/SignIn', '10.10.133.209', 'GET', '', '', '0', '2017-08-29 14:50:52', '2017-08-29 14:50:52', '00:00:00');
INSERT INTO `log_action` VALUES ('69', 'bijinshu', '/User/SignIn', '10.10.133.209', 'POST', '成功', '{\"UserName\":\"bijinshu\",\"Pwd\":\"40bd001563085fc35165329ea1ff5c5ecbdbbeef\"}', '0', '2017-08-29 14:50:55', '2017-08-29 14:50:56', '00:00:01');
INSERT INTO `log_action` VALUES ('70', '', '/User/SignIn', '10.10.133.209', 'GET', '', '', '0', '2017-08-29 14:50:56', '2017-08-29 14:50:56', '00:00:01');
INSERT INTO `log_action` VALUES ('71', '', '/User/SignIn', '10.10.133.209', 'POST', '成功', '{\"UserName\":\"bijinshu\",\"Pwd\":\"40bd001563085fc35165329ea1ff5c5ecbdbbeef\"}', '0', '2017-08-29 14:51:03', '2017-08-29 14:51:03', '00:00:01');
INSERT INTO `log_action` VALUES ('72', '', '/User/SignIn', '10.10.133.209', 'GET', '', '', '0', '2017-08-29 14:51:03', '2017-08-29 14:51:03', '00:00:01');
INSERT INTO `log_action` VALUES ('73', '', '/User/SignIn', '10.10.133.209', 'GET', '', '', '0', '2017-08-29 14:51:34', '2017-08-29 14:51:34', '00:00:00');
INSERT INTO `log_action` VALUES ('74', '', '/User/SignIn', '10.10.133.209', 'POST', '成功', '{\"UserName\":\"bijinshu\",\"Pwd\":\"40bd001563085fc35165329ea1ff5c5ecbdbbeef\"}', '0', '2017-08-29 14:51:37', '2017-08-29 14:51:39', '00:00:03');
INSERT INTO `log_action` VALUES ('75', 'bijinshu', '/Home/Index', '10.10.133.209', 'GET', '', '', '100', '2017-08-29 14:51:39', '2017-08-29 14:51:39', '00:00:01');
INSERT INTO `log_action` VALUES ('76', 'bijinshu', '/Contact/Index', '10.10.133.209', 'GET', '', '', '100', '2017-08-29 14:51:50', '2017-08-29 14:51:50', '00:00:01');
INSERT INTO `log_action` VALUES ('77', 'bijinshu', '/Contact/Index', '10.10.133.209', 'GET', '', '', '100', '2017-08-29 14:53:31', '2017-08-29 14:53:31', '00:00:00');
INSERT INTO `log_action` VALUES ('78', 'bijinshu', '/Contact/Index', '10.10.133.209', 'GET', '', '', '100', '2017-08-29 14:53:53', '2017-08-29 14:53:53', '00:00:01');
INSERT INTO `log_action` VALUES ('79', 'bijinshu', '/Contact/Index', '10.10.133.209', 'POST', '成功', '{\"Name\":\"\",\"Area\":\"\",\"Address\":\"\",\"PageIndex\":\"0\",\"PageSize\":\"10\"}', '100', '2017-08-29 14:53:54', '2017-08-29 14:53:56', '00:00:03');
INSERT INTO `log_action` VALUES ('80', 'bijinshu', '/User/SignOut', '10.10.133.209', 'GET', '', '', '100', '2017-08-29 15:03:11', '2017-08-29 15:03:11', '00:00:01');
INSERT INTO `log_action` VALUES ('81', '', '/', '10.10.133.209', 'GET', '', '', '0', '2017-08-29 15:03:11', '2017-08-29 15:03:11', '00:00:00');
INSERT INTO `log_action` VALUES ('82', '', '/User/SignIn', '10.10.133.209', 'POST', '成功', '{\"UserName\":\"bijinshu\",\"Pwd\":\"40bd001563085fc35165329ea1ff5c5ecbdbbeef\"}', '0', '2017-08-29 15:03:13', '2017-08-29 15:03:13', '00:00:01');
INSERT INTO `log_action` VALUES ('83', 'bijinshu', '/Home/Index', '10.10.133.209', 'GET', '', '', '100', '2017-08-29 15:03:13', '2017-08-29 15:03:13', '00:00:00');
INSERT INTO `log_action` VALUES ('84', 'bijinshu', '/', '10.10.133.209', 'GET', '', '', '100', '2017-08-29 15:04:37', '2017-08-29 15:04:37', '00:00:01');
INSERT INTO `log_action` VALUES ('85', 'bijinshu', '/Contact/Index', '10.10.133.209', 'GET', '', '', '100', '2017-08-29 15:11:13', '2017-08-29 15:11:13', '00:00:01');
INSERT INTO `log_action` VALUES ('86', 'bijinshu', '/Contact/Index', '10.10.133.209', 'POST', '成功', '{\"Name\":\"\",\"Area\":\"\",\"Address\":\"\",\"PageIndex\":\"0\",\"PageSize\":\"10\"}', '100', '2017-08-29 15:11:13', '2017-08-29 15:11:14', '00:00:01');
INSERT INTO `log_action` VALUES ('87', 'bijinshu', '/Contact/Index', '10.10.133.209', 'GET', '', '', '100', '2017-08-29 15:11:17', '2017-08-29 15:11:17', '00:00:01');
INSERT INTO `log_action` VALUES ('88', 'bijinshu', '/Contact/Index', '10.10.133.209', 'POST', '成功', '{\"Name\":\"\",\"Area\":\"\",\"Address\":\"\",\"PageIndex\":\"0\",\"PageSize\":\"10\"}', '100', '2017-08-29 15:11:17', '2017-08-29 15:11:17', '00:00:01');
INSERT INTO `log_action` VALUES ('89', 'bijinshu', '/Contact/Index', '10.10.133.209', 'GET', '', '', '100', '2017-08-29 15:11:19', '2017-08-29 15:11:19', '00:00:01');
INSERT INTO `log_action` VALUES ('90', 'bijinshu', '/Contact/Index', '10.10.133.209', 'POST', '成功', '{\"Name\":\"\",\"Area\":\"\",\"Address\":\"\",\"PageIndex\":\"0\",\"PageSize\":\"10\"}', '100', '2017-08-29 15:11:19', '2017-08-29 15:11:19', '00:00:00');
INSERT INTO `log_action` VALUES ('91', 'bijinshu', '/Contact/Index', '10.10.133.209', 'GET', '', '', '100', '2017-08-29 15:11:21', '2017-08-29 15:11:21', '00:00:01');
INSERT INTO `log_action` VALUES ('92', 'bijinshu', '/Contact/Index', '10.10.133.209', 'POST', '成功', '{\"Name\":\"\",\"Area\":\"\",\"Address\":\"\",\"PageIndex\":\"0\",\"PageSize\":\"10\"}', '100', '2017-08-29 15:11:21', '2017-08-29 15:11:21', '00:00:01');
INSERT INTO `log_action` VALUES ('93', 'bijinshu', '/Contact/Index', '10.10.133.209', 'GET', '', '', '100', '2017-08-29 15:11:22', '2017-08-29 15:11:22', '00:00:01');
INSERT INTO `log_action` VALUES ('94', 'bijinshu', '/Contact/Index', '10.10.133.209', 'POST', '成功', '{\"Name\":\"\",\"Area\":\"\",\"Address\":\"\",\"PageIndex\":\"0\",\"PageSize\":\"10\"}', '100', '2017-08-29 15:11:22', '2017-08-29 15:11:22', '00:00:01');
INSERT INTO `log_action` VALUES ('95', 'bijinshu', '/Contact/Index', '10.10.133.209', 'GET', '', '', '100', '2017-08-29 15:11:26', '2017-08-29 15:11:26', '00:00:00');
INSERT INTO `log_action` VALUES ('96', 'bijinshu', '/Contact/Index', '10.10.133.209', 'POST', '成功', '{\"Name\":\"\",\"Area\":\"\",\"Address\":\"\",\"PageIndex\":\"0\",\"PageSize\":\"10\"}', '100', '2017-08-29 15:11:26', '2017-08-29 15:11:26', '00:00:00');
INSERT INTO `log_action` VALUES ('97', 'bijinshu', '/Contact/Index', '10.10.133.209', 'GET', '', '', '100', '2017-08-29 15:11:28', '2017-08-29 15:11:28', '00:00:01');
INSERT INTO `log_action` VALUES ('98', 'bijinshu', '/Contact/Index', '10.10.133.209', 'POST', '成功', '{\"Name\":\"\",\"Area\":\"\",\"Address\":\"\",\"PageIndex\":\"0\",\"PageSize\":\"10\"}', '100', '2017-08-29 15:11:28', '2017-08-29 15:11:28', '00:00:00');
INSERT INTO `log_action` VALUES ('99', '', '/User/SignIn', '10.10.133.209', 'GET', '', '', '0', '2017-08-29 16:05:00', '2017-08-29 16:05:00', '00:00:01');
INSERT INTO `log_action` VALUES ('100', '', '/User/SignIn', '10.10.133.209', 'POST', '成功', '{\"UserName\":\"bijinshu\",\"Pwd\":\"40bd001563085fc35165329ea1ff5c5ecbdbbeef\"}', '0', '2017-08-29 16:05:02', '2017-08-29 16:05:03', '00:00:02');
INSERT INTO `log_action` VALUES ('101', 'bijinshu', '/Home/Index', '10.10.133.209', 'GET', '', '', '100', '2017-08-29 16:05:04', '2017-08-29 16:05:04', '00:00:01');
INSERT INTO `log_action` VALUES ('102', 'bijinshu', '/Contact/Index', '10.10.133.209', 'GET', '', '', '100', '2017-08-29 16:12:56', '2017-08-29 16:12:56', '00:00:01');
INSERT INTO `log_action` VALUES ('103', 'bijinshu', '/Contact/Index', '10.10.133.209', 'POST', '成功', '{\"Name\":\"\",\"Area\":\"\",\"Address\":\"\",\"PageIndex\":\"0\",\"PageSize\":\"10\"}', '100', '2017-08-29 16:12:56', '2017-08-29 16:12:58', '00:00:03');
INSERT INTO `log_action` VALUES ('104', 'bijinshu', '/Contact/Index', '10.10.133.209', 'GET', '', '', '100', '2017-08-29 16:13:19', '2017-08-29 16:13:19', '00:00:01');
INSERT INTO `log_action` VALUES ('105', 'bijinshu', '/Contact/Index', '10.10.133.209', 'POST', '成功', '{\"Name\":\"\",\"Area\":\"\",\"Address\":\"\",\"PageIndex\":\"0\",\"PageSize\":\"10\"}', '100', '2017-08-29 16:13:19', '2017-08-29 16:13:19', '00:00:01');
INSERT INTO `log_action` VALUES ('106', 'bijinshu', '/Home/Index', '10.10.133.209', 'GET', '', '', '100', '2017-08-29 16:14:07', '2017-08-29 16:14:07', '00:00:01');
INSERT INTO `log_action` VALUES ('107', 'bijinshu', '/', '10.10.133.209', 'GET', '', '', '100', '2017-08-29 16:28:33', '2017-08-29 16:28:33', '00:00:01');
INSERT INTO `log_action` VALUES ('108', 'bijinshu', '/User/SignIn', '10.10.133.209', 'POST', '成功', '{\"UserName\":\"bijinshu\",\"Pwd\":\"40bd001563085fc35165329ea1ff5c5ecbdbbeef\"}', '100', '2017-08-29 16:45:46', '2017-08-29 16:45:48', '00:00:03');
INSERT INTO `log_action` VALUES ('109', 'bijinshu', '/Home/Index', '10.10.133.209', 'GET', '', '', '100', '2017-08-29 16:45:48', '2017-08-29 16:45:48', '00:00:00');
INSERT INTO `log_action` VALUES ('110', '', '/User/SignIn', '10.10.133.209', 'GET', '', '', '0', '2017-08-29 18:14:23', '2017-08-29 18:14:23', '00:00:00');
INSERT INTO `log_action` VALUES ('111', '', '/', '10.10.133.209', 'GET', '', '', '0', '2017-08-29 18:15:49', '2017-08-29 18:15:49', '00:00:01');
INSERT INTO `log_action` VALUES ('112', '', '/', '10.10.133.209', 'GET', '', '', '0', '2017-08-29 18:16:48', '2017-08-29 18:16:48', '00:00:01');
INSERT INTO `log_action` VALUES ('113', '', '/', '10.10.133.209', 'GET', '', '', '0', '2017-08-29 18:16:53', '2017-08-29 18:16:53', '00:00:01');
INSERT INTO `log_action` VALUES ('114', '', '/User/SignIn', '10.10.133.209', 'POST', '成功', '{\"UserName\":\"bijinshu\",\"Pwd\":\"40bd001563085fc35165329ea1ff5c5ecbdbbeef\"}', '0', '2017-08-29 18:16:57', '2017-08-29 18:17:00', '00:00:03');
INSERT INTO `log_action` VALUES ('115', 'bijinshu', '/Home/Index', '10.10.133.209', 'GET', '', '', '100', '2017-08-29 18:17:00', '2017-08-29 18:17:00', '00:00:01');
INSERT INTO `log_action` VALUES ('116', 'bijinshu', '/Home/Index', '10.10.133.209', 'GET', '', '', '100', '2017-08-29 18:18:20', '2017-08-29 18:18:20', '00:00:00');
INSERT INTO `log_action` VALUES ('117', 'bijinshu', '/Home/Index', '10.10.133.209', 'GET', '', '', '100', '2017-08-29 18:19:30', '2017-08-29 18:19:30', '00:00:00');
INSERT INTO `log_action` VALUES ('118', 'bijinshu', '/Contact/Index', '10.10.133.209', 'GET', '', '', '100', '2017-08-29 18:20:33', '2017-08-29 18:20:33', '00:00:00');
INSERT INTO `log_action` VALUES ('119', 'bijinshu', '/Contact/Index', '10.10.133.209', 'POST', '成功', '{\"Name\":\"\",\"Area\":\"\",\"Address\":\"\",\"PageIndex\":\"0\",\"PageSize\":\"10\"}', '100', '2017-08-29 18:20:34', '2017-08-29 18:20:34', '00:00:01');
INSERT INTO `log_action` VALUES ('120', 'bijinshu', '/Contact/Index', '10.10.133.209', 'GET', '', '', '100', '2017-08-29 18:36:11', '2017-08-29 18:36:11', '00:00:01');
INSERT INTO `log_action` VALUES ('121', 'bijinshu', '/Contact/Index', '10.10.133.209', 'POST', '成功', '{\"Name\":\"\",\"Area\":\"\",\"Address\":\"\",\"PageIndex\":\"0\",\"PageSize\":\"10\"}', '100', '2017-08-29 18:36:11', '2017-08-29 18:36:11', '00:00:01');
INSERT INTO `log_action` VALUES ('122', 'bijinshu', '/Contact/Index', '10.10.133.209', 'GET', '', '', '100', '2017-08-29 18:37:49', '2017-08-29 18:37:49', '00:00:00');
INSERT INTO `log_action` VALUES ('123', 'bijinshu', '/Contact/Index', '10.10.133.209', 'POST', '成功', '{\"Name\":\"\",\"Area\":\"\",\"Address\":\"\",\"PageIndex\":\"0\",\"PageSize\":\"10\"}', '100', '2017-08-29 18:37:50', '2017-08-29 18:37:50', '00:00:01');
INSERT INTO `log_action` VALUES ('124', '', '/', '10.10.133.209', 'GET', '', '', '0', '2017-08-30 09:34:34', '2017-08-30 09:34:35', '00:00:01');
INSERT INTO `log_action` VALUES ('125', '', '/User/SignIn', '10.10.133.209', 'POST', '成功', '{\"UserName\":\"bijinshu\",\"Pwd\":\"40bd001563085fc35165329ea1ff5c5ecbdbbeef\"}', '0', '2017-08-30 09:34:39', '2017-08-30 09:34:41', '00:00:03');
INSERT INTO `log_action` VALUES ('126', 'bijinshu', '/Home/Index', '10.10.133.209', 'GET', '', '', '100', '2017-08-30 09:34:41', '2017-08-30 09:34:41', '00:00:00');
INSERT INTO `log_action` VALUES ('127', 'bijinshu', '/Contact/Index', '10.10.133.209', 'GET', '', '', '100', '2017-08-30 09:35:32', '2017-08-30 09:35:32', '00:00:01');
INSERT INTO `log_action` VALUES ('128', 'bijinshu', '/Contact/Index', '10.10.133.209', 'POST', '成功', '{\"Name\":\"\",\"Area\":\"\",\"Address\":\"\",\"PageIndex\":\"0\",\"PageSize\":\"10\"}', '100', '2017-08-30 09:35:34', '2017-08-30 09:35:34', '00:00:01');
INSERT INTO `log_action` VALUES ('129', '', '/', '10.10.133.108', 'GET', '', '', '0', '2017-12-28 09:55:00', '2017-12-28 09:55:00', '00:00:00');
INSERT INTO `log_action` VALUES ('130', '', '/User/SignIn', '10.10.133.108', 'POST', '成功', '{\"UserName\":\"bijinshu\",\"Pwd\":\"40bd001563085fc35165329ea1ff5c5ecbdbbeef\"}', '0', '2017-12-28 09:55:04', '2017-12-28 09:55:06', '00:00:02');
INSERT INTO `log_action` VALUES ('131', 'bijinshu', '/Home/Index', '10.10.133.108', 'GET', '', '', '100', '2017-12-28 09:55:06', '2017-12-28 09:55:06', '00:00:01');
INSERT INTO `log_action` VALUES ('132', 'bijinshu', '/Home/Index', '10.10.133.108', 'GET', '', '', '100', '2017-12-28 09:55:12', '2017-12-28 09:55:12', '00:00:00');
INSERT INTO `log_action` VALUES ('133', '', '/', '10.10.133.108', 'GET', '', '', '0', '2017-12-28 11:19:40', '2017-12-28 11:19:42', '00:00:02');
INSERT INTO `log_action` VALUES ('134', '', '/User/SignIn', '10.10.133.108', 'GET', '', '', '0', '2017-12-28 13:06:46', '2017-12-28 13:06:46', '00:00:01');
INSERT INTO `log_action` VALUES ('135', '', '/User/SignIn', '10.10.133.108', 'GET', '', '', '0', '2017-12-28 13:09:06', '2017-12-28 13:09:06', '00:00:01');
INSERT INTO `log_action` VALUES ('136', '', '/User/SignIn', '10.10.133.108', 'GET', '', '', '0', '2017-12-28 14:08:29', '2017-12-28 14:08:29', '00:00:01');
INSERT INTO `log_action` VALUES ('137', '', '/User/SignIn', '10.10.133.108', 'GET', '', '', '0', '2017-12-28 14:11:09', '2017-12-28 14:11:09', '00:00:01');
INSERT INTO `log_action` VALUES ('138', '', '/User/SignIn', '10.10.133.108', 'GET', '', '', '0', '2017-12-28 14:11:13', '2017-12-28 14:11:13', '00:00:00');
INSERT INTO `log_action` VALUES ('139', '', '/User/SignIn', '10.10.133.108', 'GET', '', '', '0', '2017-12-28 14:14:26', '2017-12-28 14:14:26', '00:00:01');
INSERT INTO `log_action` VALUES ('140', '', '/User/SignIn', '10.10.133.108', 'POST', '成功', '{\"UserName\":\"bijinshu\",\"Pwd\":\"40bd001563085fc35165329ea1ff5c5ecbdbbeef\"}', '0', '2017-12-28 14:14:37', '2017-12-28 14:17:39', '00:03:03');
INSERT INTO `log_action` VALUES ('141', '', '/User/SignIn', '10.10.133.108', 'POST', '成功', '{\"UserName\":\"bijinshu\",\"Pwd\":\"40bd001563085fc35165329ea1ff5c5ecbdbbeef\"}', '0', '2017-12-28 14:19:27', '2017-12-28 14:20:49', '00:01:22');
INSERT INTO `log_action` VALUES ('142', '', '/User/SignIn', '10.10.133.108', 'GET', '', '', '0', '2017-12-28 14:20:49', '2017-12-28 14:20:49', '00:00:00');
INSERT INTO `log_action` VALUES ('143', '', '/User/SignIn', '10.10.133.108', 'GET', '', '', '0', '2017-12-28 14:23:36', '2017-12-28 14:23:37', '00:00:02');
INSERT INTO `log_action` VALUES ('144', '', '/User/SignIn', '10.10.133.108', 'POST', '成功', '{\"UserName\":\"bijinshu\",\"Pwd\":\"40bd001563085fc35165329ea1ff5c5ecbdbbeef\"}', '0', '2017-12-28 14:24:09', '2017-12-28 14:25:00', '00:00:52');
INSERT INTO `log_action` VALUES ('145', '', '/User/SignIn', '10.10.133.108', 'GET', '', '', '0', '2017-12-28 14:25:41', '2017-12-28 14:25:41', '00:00:01');
INSERT INTO `log_action` VALUES ('146', '', '/User/SignIn', '10.10.133.108', 'GET', '', '', '0', '2017-12-28 14:26:51', '2017-12-28 14:26:52', '00:00:01');
INSERT INTO `log_action` VALUES ('147', '', '/User/SignIn', '10.10.133.108', 'POST', '成功', '{\"UserName\":\"bijinshu\",\"Pwd\":\"40bd001563085fc35165329ea1ff5c5ecbdbbeef\"}', '0', '2017-12-28 14:27:01', '2017-12-28 14:27:02', '00:00:02');
INSERT INTO `log_action` VALUES ('148', '', '/User/SignIn', '10.10.133.108', 'GET', '', '', '0', '2017-12-28 14:27:02', '2017-12-28 14:27:02', '00:00:01');
INSERT INTO `log_action` VALUES ('149', '', '/User/SignIn', '10.10.133.108', 'GET', '', '', '0', '2017-12-28 14:27:08', '2017-12-28 14:27:08', '00:00:01');
INSERT INTO `log_action` VALUES ('150', '', '/User/SignIn', '10.10.133.108', 'POST', '成功', '{\"UserName\":\"bijinshu\",\"Pwd\":\"40bd001563085fc35165329ea1ff5c5ecbdbbeef\"}', '0', '2017-12-28 14:27:18', '2017-12-28 14:27:18', '00:00:01');
INSERT INTO `log_action` VALUES ('151', '', '/User/SignIn', '10.10.133.108', 'GET', '', '', '0', '2017-12-28 14:27:18', '2017-12-28 14:27:18', '00:00:00');
INSERT INTO `log_action` VALUES ('152', '', '/User/SignIn', '10.10.133.108', 'GET', '', '', '0', '2017-12-28 14:45:16', '2017-12-28 14:45:17', '00:00:01');
INSERT INTO `log_action` VALUES ('153', '', '/User/SignIn', '10.10.133.108', 'POST', '成功', '{\"UserName\":\"bijinshu\",\"Pwd\":\"40bd001563085fc35165329ea1ff5c5ecbdbbeef\"}', '0', '2017-12-28 14:45:35', '2017-12-28 14:45:36', '00:00:02');
INSERT INTO `log_action` VALUES ('154', 'bijinshu', '/Home/Index', '10.10.133.108', 'GET', '', '', '100', '2017-12-28 14:45:36', '2017-12-28 14:45:36', '00:00:00');
INSERT INTO `log_action` VALUES ('155', 'bijinshu', '/', '10.10.133.108', 'GET', '', '', '100', '2017-12-28 14:53:15', '2017-12-28 14:53:15', '00:00:01');
INSERT INTO `log_action` VALUES ('156', '', '/User/SignIn', '10.10.133.108', 'GET', '', '', '0', '2017-12-28 14:55:15', '2017-12-28 14:55:15', '00:00:01');
INSERT INTO `log_action` VALUES ('157', '', '/User/SignIn', '10.10.133.108', 'POST', '成功', '{\"UserName\":\"bijinshu\",\"Pwd\":\"40bd001563085fc35165329ea1ff5c5ecbdbbeef\"}', '0', '2017-12-28 14:55:25', '2017-12-28 14:56:21', '00:00:56');
INSERT INTO `log_action` VALUES ('158', 'bijinshu', '/Home/Index', '10.10.133.108', 'GET', '', '', '100', '2017-12-28 14:56:26', '2017-12-28 14:56:26', '00:00:01');
INSERT INTO `log_action` VALUES ('159', 'bijinshu', '/', '10.10.133.108', 'GET', '', '', '100', '2017-12-28 15:00:26', '2017-12-28 15:00:26', '00:00:00');
INSERT INTO `log_action` VALUES ('160', 'bijinshu', '/User/SignIn', '10.10.133.108', 'GET', '', '', '100', '2017-12-28 15:05:24', '2017-12-28 15:05:24', '00:00:01');
INSERT INTO `log_action` VALUES ('161', 'bijinshu', '/', '10.10.133.108', 'GET', '', '', '100', '2017-12-28 15:14:35', '2017-12-28 15:14:35', '00:00:01');
INSERT INTO `log_action` VALUES ('162', 'bijinshu', '/', '10.10.133.108', 'GET', '', '', '100', '2017-12-28 15:17:03', '2017-12-28 15:17:03', '00:00:00');
INSERT INTO `log_action` VALUES ('163', 'bijinshu', '/', '10.10.133.108', 'GET', '', '', '100', '2017-12-28 15:17:53', '2017-12-28 15:17:53', '00:00:00');
INSERT INTO `log_action` VALUES ('164', 'bijinshu', '/', '10.10.133.108', 'GET', '', '', '100', '2017-12-28 15:19:54', '2017-12-28 15:19:54', '00:00:00');
INSERT INTO `log_action` VALUES ('165', 'bijinshu', '/', '10.10.133.108', 'GET', '', '', '100', '2017-12-28 15:20:50', '2017-12-28 15:20:50', '00:00:01');
INSERT INTO `log_action` VALUES ('166', 'bijinshu', '/', '10.10.133.108', 'GET', '', '', '100', '2017-12-28 15:21:48', '2017-12-28 15:21:48', '00:00:01');
INSERT INTO `log_action` VALUES ('167', 'bijinshu', '/', '10.10.133.108', 'GET', '', '', '100', '2017-12-28 15:39:54', '2017-12-28 15:39:55', '00:00:01');
INSERT INTO `log_action` VALUES ('168', 'bijinshu', '/Contact/Index', '10.10.133.108', 'GET', '', '', '100', '2017-12-28 15:49:06', '2017-12-28 15:49:06', '00:00:01');
INSERT INTO `log_action` VALUES ('169', 'bijinshu', '/Contact/Index', '10.10.133.108', 'POST', '成功', '{\"Name\":\"\",\"Area\":\"\",\"Address\":\"\",\"PageIndex\":\"0\",\"PageSize\":\"10\"}', '100', '2017-12-28 15:49:09', '2017-12-28 15:49:09', '00:00:01');
INSERT INTO `log_action` VALUES ('170', 'bijinshu', '/User/SignIn', '10.10.133.108', 'GET', '', '', '100', '2017-12-28 18:19:28', '2017-12-28 18:19:29', '00:00:01');
INSERT INTO `log_action` VALUES ('171', 'bijinshu', '/User/SignIn', '10.10.133.108', 'POST', '成功', '{\"UserName\":\"bijinshu\",\"Pwd\":\"40bd001563085fc35165329ea1ff5c5ecbdbbeef\"}', '100', '2017-12-28 18:19:41', '2017-12-28 18:19:42', '00:00:02');
INSERT INTO `log_action` VALUES ('172', 'bijinshu', '/Home/Index', '10.10.133.108', 'GET', '', '', '100', '2017-12-28 18:19:42', '2017-12-28 18:19:42', '00:00:01');
INSERT INTO `log_action` VALUES ('173', 'bijinshu', '/', '10.10.133.108', 'GET', '', '', '100', '2017-12-28 19:03:56', '2017-12-28 19:03:56', '00:00:01');
INSERT INTO `log_action` VALUES ('174', 'bijinshu', '/User/SignIn', '10.10.133.108', 'GET', '', '', '100', '2017-12-28 19:04:23', '2017-12-28 19:04:23', '00:00:01');
INSERT INTO `log_action` VALUES ('175', 'bijinshu', '/User/SignIn', '10.10.133.108', 'POST', '成功', '{\"UserName\":\"bijinshu\",\"Pwd\":\"40bd001563085fc35165329ea1ff5c5ecbdbbeef\"}', '100', '2017-12-28 19:04:25', '2017-12-28 19:04:25', '00:00:01');
INSERT INTO `log_action` VALUES ('176', 'bijinshu', '/Home/Index', '10.10.133.108', 'GET', '', '', '100', '2017-12-28 19:04:25', '2017-12-28 19:04:25', '00:00:01');
INSERT INTO `log_action` VALUES ('177', '', '/User/SignIn', '10.10.133.108', 'GET', '', '', '0', '2017-12-28 23:10:27', '2017-12-28 23:10:27', '00:00:01');
INSERT INTO `log_action` VALUES ('178', '', '/User/SignIn', '10.10.133.108', 'GET', '', '', '0', '2017-12-28 23:13:46', '2017-12-28 23:13:46', '00:00:00');
INSERT INTO `log_action` VALUES ('179', '', '/User/SignIn', '10.10.133.108', 'GET', '', '', '0', '2018-01-02 09:40:25', '2018-01-02 09:40:26', '00:00:01');
INSERT INTO `log_action` VALUES ('180', '', '/User/SignIn', '10.10.133.108', 'POST', '成功', '{\"UserName\":\"bijinshu\",\"Pwd\":\"40bd001563085fc35165329ea1ff5c5ecbdbbeef\"}', '0', '2018-01-02 09:40:30', '2018-01-02 09:40:31', '00:00:01');
INSERT INTO `log_action` VALUES ('181', 'bijinshu', '/Home/Index', '10.10.133.108', 'GET', '', '', '100', '2018-01-02 09:40:31', '2018-01-02 09:40:31', '00:00:00');
INSERT INTO `log_action` VALUES ('182', 'bijinshu', '/User/SignIn', '10.10.133.108', 'GET', '', '', '100', '2018-01-02 17:34:16', '2018-01-02 17:34:17', '00:00:01');
INSERT INTO `log_action` VALUES ('183', 'bijinshu', '/User/SignIn', '10.10.133.108', 'POST', '成功', '{\"UserName\":\"bijinshu\",\"Pwd\":\"40bd001563085fc35165329ea1ff5c5ecbdbbeef\"}', '100', '2018-01-02 17:35:17', '2018-01-02 17:35:18', '00:00:02');
INSERT INTO `log_action` VALUES ('184', 'bijinshu', '/Home/Index', '10.10.133.108', 'GET', '', '', '100', '2018-01-02 17:35:18', '2018-01-02 17:35:18', '00:00:01');
INSERT INTO `log_action` VALUES ('185', 'bijinshu', '/Contact/Index', '10.10.133.108', 'GET', '', '', '100', '2018-01-02 17:35:23', '2018-01-02 17:35:23', '00:00:01');
INSERT INTO `log_action` VALUES ('186', 'bijinshu', '/Contact/Index', '10.10.133.108', 'POST', '成功', '{\"Name\":\"\",\"Area\":\"\",\"Address\":\"\",\"PageIndex\":\"0\",\"PageSize\":\"10\"}', '100', '2018-01-02 17:35:23', '2018-01-02 17:35:24', '00:00:01');
INSERT INTO `log_action` VALUES ('187', 'bijinshu', '/Contact/Edit', '10.10.133.108', 'POST', '成功', '{\"Id\":\"1\",\"ContactName\":\"张海川\",\"Mobile\":\"15801992799\",\"Address\":\"江苏省南京市雨花台区宁双路\",\"BirthDate\":\"2016-02-02T00:00:00\",\"QQ\":\"914023961\",\"Email\":\"bijinshu@163.com\",\"Gender\":\"男\"}', '100', '2018-01-02 17:36:27', '2018-01-02 17:36:27', '00:00:01');
INSERT INTO `log_action` VALUES ('188', 'bijinshu', '/Contact/Index', '10.10.133.108', 'POST', '成功', '{\"Name\":\"\",\"Area\":\"\",\"Address\":\"\",\"PageIndex\":\"0\",\"PageSize\":\"10\"}', '100', '2018-01-02 17:36:27', '2018-01-02 17:36:27', '00:00:00');
INSERT INTO `log_action` VALUES ('189', 'bijinshu', '/Contact/Index', '10.10.133.108', 'POST', '成功', '{\"Name\":\"\",\"Area\":\"\",\"Address\":\"\",\"PageIndex\":\"1\",\"PageSize\":\"10\"}', '100', '2018-01-02 17:36:50', '2018-01-02 17:36:50', '00:00:00');
INSERT INTO `log_action` VALUES ('190', 'bijinshu', '/Contact/Index', '10.10.133.108', 'POST', '成功', '{\"Name\":\"\",\"Area\":\"\",\"Address\":\"\",\"PageIndex\":\"2\",\"PageSize\":\"10\"}', '100', '2018-01-02 17:36:52', '2018-01-02 17:36:52', '00:00:00');
INSERT INTO `log_action` VALUES ('191', 'bijinshu', '/Contact/Index', '10.10.133.108', 'POST', '成功', '{\"Name\":\"\",\"Area\":\"\",\"Address\":\"\",\"PageIndex\":\"1\",\"PageSize\":\"10\"}', '100', '2018-01-02 17:36:54', '2018-01-02 17:36:54', '00:00:01');
INSERT INTO `log_action` VALUES ('192', 'bijinshu', '/Contact/Index', '10.10.133.108', 'POST', '成功', '{\"Name\":\"\",\"Area\":\"\",\"Address\":\"\",\"PageIndex\":\"0\",\"PageSize\":\"10\"}', '100', '2018-01-02 17:36:55', '2018-01-02 17:36:55', '00:00:00');
INSERT INTO `log_action` VALUES ('193', 'bijinshu', '/Contact/Index', '10.10.133.108', 'GET', '', '', '100', '2018-01-02 17:51:21', '2018-01-02 17:51:21', '00:00:00');
INSERT INTO `log_action` VALUES ('194', 'bijinshu', '/Contact/Index', '10.10.133.108', 'POST', '成功', '{\"Name\":\"\",\"Area\":\"\",\"Address\":\"\",\"PageIndex\":\"0\",\"PageSize\":\"10\"}', '100', '2018-01-02 17:51:24', '2018-01-02 17:51:24', '00:00:01');
INSERT INTO `log_action` VALUES ('195', 'bijinshu', '/Home/Index', '10.10.133.108', 'GET', '', '', '100', '2018-01-02 17:55:47', '2018-01-02 17:55:47', '00:00:01');
INSERT INTO `log_action` VALUES ('196', 'bijinshu', '/Contact/Index', '10.10.133.108', 'GET', '', '', '100', '2018-01-02 18:28:25', '2018-01-02 18:28:25', '00:00:01');
INSERT INTO `log_action` VALUES ('197', 'bijinshu', '/Contact/Index', '10.10.133.108', 'POST', '成功', '{\"Name\":\"\",\"Area\":\"\",\"Address\":\"\",\"PageIndex\":\"0\",\"PageSize\":\"10\"}', '100', '2018-01-02 18:28:25', '2018-01-02 18:28:25', '00:00:01');
INSERT INTO `log_action` VALUES ('198', 'bijinshu', '/Contact/Index', '10.10.133.108', 'GET', '', '', '100', '2018-01-02 18:28:28', '2018-01-02 18:28:28', '00:00:00');
INSERT INTO `log_action` VALUES ('199', 'bijinshu', '/Contact/Index', '10.10.133.108', 'POST', '成功', '{\"Name\":\"\",\"Area\":\"\",\"Address\":\"\",\"PageIndex\":\"0\",\"PageSize\":\"10\"}', '100', '2018-01-02 18:28:28', '2018-01-02 18:28:29', '00:00:01');
INSERT INTO `log_action` VALUES ('200', 'bijinshu', '/Contact/Index', '10.10.133.108', 'GET', '', '', '100', '2018-01-02 18:28:30', '2018-01-02 18:28:30', '00:00:00');
INSERT INTO `log_action` VALUES ('201', 'bijinshu', '/Contact/Index', '10.10.133.108', 'POST', '成功', '{\"Name\":\"\",\"Area\":\"\",\"Address\":\"\",\"PageIndex\":\"0\",\"PageSize\":\"10\"}', '100', '2018-01-02 18:28:30', '2018-01-02 18:28:30', '00:00:00');
INSERT INTO `log_action` VALUES ('202', 'bijinshu', '/Contact/Index', '10.10.133.108', 'GET', '', '', '100', '2018-01-02 18:28:32', '2018-01-02 18:28:32', '00:00:00');
INSERT INTO `log_action` VALUES ('203', 'bijinshu', '/Contact/Index', '10.10.133.108', 'POST', '成功', '{\"Name\":\"\",\"Area\":\"\",\"Address\":\"\",\"PageIndex\":\"0\",\"PageSize\":\"10\"}', '100', '2018-01-02 18:28:32', '2018-01-02 18:28:32', '00:00:00');
INSERT INTO `log_action` VALUES ('204', 'bijinshu', '/Contact/Index', '10.10.133.108', 'GET', '', '', '100', '2018-01-02 18:28:37', '2018-01-02 18:28:38', '00:00:01');
INSERT INTO `log_action` VALUES ('205', 'bijinshu', '/Contact/Index', '10.10.133.108', 'POST', '成功', '{\"Name\":\"\",\"Area\":\"\",\"Address\":\"\",\"PageIndex\":\"0\",\"PageSize\":\"10\"}', '100', '2018-01-02 18:28:38', '2018-01-02 18:28:38', '00:00:01');
INSERT INTO `log_action` VALUES ('206', 'bijinshu', '/Contact/Index', '10.10.133.108', 'GET', '', '', '100', '2018-01-02 18:28:39', '2018-01-02 18:28:39', '00:00:01');
INSERT INTO `log_action` VALUES ('207', 'bijinshu', '/Contact/Index', '10.10.133.108', 'POST', '成功', '{\"Name\":\"\",\"Area\":\"\",\"Address\":\"\",\"PageIndex\":\"0\",\"PageSize\":\"10\"}', '100', '2018-01-02 18:28:39', '2018-01-02 18:28:39', '00:00:00');
INSERT INTO `log_action` VALUES ('208', 'bijinshu', '/Contact/Index', '10.10.133.108', 'GET', '', '', '100', '2018-01-02 18:28:43', '2018-01-02 18:28:43', '00:00:00');
INSERT INTO `log_action` VALUES ('209', 'bijinshu', '/Contact/Index', '10.10.133.108', 'POST', '成功', '{\"Name\":\"\",\"Area\":\"\",\"Address\":\"\",\"PageIndex\":\"0\",\"PageSize\":\"10\"}', '100', '2018-01-02 18:28:43', '2018-01-02 18:28:43', '00:00:00');
INSERT INTO `log_action` VALUES ('210', 'bijinshu', '/Contact/Index', '10.10.133.108', 'GET', '', '', '100', '2018-01-02 18:28:44', '2018-01-02 18:28:44', '00:00:01');
INSERT INTO `log_action` VALUES ('211', 'bijinshu', '/Contact/Index', '10.10.133.108', 'POST', '成功', '{\"Name\":\"\",\"Area\":\"\",\"Address\":\"\",\"PageIndex\":\"0\",\"PageSize\":\"10\"}', '100', '2018-01-02 18:28:44', '2018-01-02 18:28:44', '00:00:01');
INSERT INTO `log_action` VALUES ('212', 'bijinshu', '/Contact/Index', '10.10.133.108', 'GET', '', '', '100', '2018-01-02 18:28:45', '2018-01-02 18:28:45', '00:00:00');
INSERT INTO `log_action` VALUES ('213', 'bijinshu', '/Contact/Index', '10.10.133.108', 'POST', '成功', '{\"Name\":\"\",\"Area\":\"\",\"Address\":\"\",\"PageIndex\":\"0\",\"PageSize\":\"10\"}', '100', '2018-01-02 18:28:45', '2018-01-02 18:28:46', '00:00:01');
INSERT INTO `log_action` VALUES ('214', 'bijinshu', '/Home/Index', '10.10.133.108', 'GET', '', '', '100', '2018-01-02 18:29:25', '2018-01-02 18:29:25', '00:00:00');
INSERT INTO `log_action` VALUES ('215', 'bijinshu', '/User/SignIn', '10.10.133.108', 'GET', '', '', '100', '2018-01-03 09:25:19', '2018-01-03 09:25:19', '00:00:00');
INSERT INTO `log_action` VALUES ('216', 'bijinshu', '/User/SignIn', '10.10.133.108', 'POST', '成功', '{\"UserName\":\"bijinshu\",\"Pwd\":\"40bd001563085fc35165329ea1ff5c5ecbdbbeef\"}', '100', '2018-01-03 09:25:22', '2018-01-03 09:25:22', '00:00:01');
INSERT INTO `log_action` VALUES ('217', 'bijinshu', '/Home/Index', '10.10.133.108', 'GET', '', '', '100', '2018-01-03 09:25:22', '2018-01-03 09:25:22', '00:00:00');
INSERT INTO `log_action` VALUES ('218', 'bijinshu', '/User/SignIn', '10.10.133.108', 'GET', '', '', '100', '2018-01-03 11:47:21', '2018-01-03 11:47:22', '00:00:01');
INSERT INTO `log_action` VALUES ('219', 'bijinshu', '/User/SignIn', '10.10.133.108', 'POST', '成功', '{\"UserName\":\"bijinshu\",\"Pwd\":\"40bd001563085fc35165329ea1ff5c5ecbdbbeef\"}', '100', '2018-01-03 11:47:25', '2018-01-03 11:47:26', '00:00:01');
INSERT INTO `log_action` VALUES ('220', 'bijinshu', '/Home/Index', '10.10.133.108', 'GET', '', '', '100', '2018-01-03 11:47:27', '2018-01-03 11:47:27', '00:00:01');
INSERT INTO `log_action` VALUES ('221', 'bijinshu', '/Home/Index', '10.10.133.108', 'GET', '', '', '100', '2018-01-03 11:48:13', '2018-01-03 11:48:13', '00:00:00');
INSERT INTO `log_action` VALUES ('222', 'bijinshu', '/User/SignIn', '10.10.133.108', 'GET', '', '', '100', '2018-01-03 14:15:16', '2018-01-03 14:15:16', '00:00:01');
INSERT INTO `log_action` VALUES ('223', 'bijinshu', '/User/SignIn', '10.10.133.108', 'POST', '成功', '{\"UserName\":\"bijinshu\",\"Pwd\":\"40bd001563085fc35165329ea1ff5c5ecbdbbeef\"}', '100', '2018-01-03 14:15:20', '2018-01-03 14:15:21', '00:00:01');
INSERT INTO `log_action` VALUES ('224', 'bijinshu', '/Home/Index', '10.10.133.108', 'GET', '', '', '100', '2018-01-03 14:15:21', '2018-01-03 14:15:21', '00:00:00');
INSERT INTO `log_action` VALUES ('225', 'bijinshu', '/Home/Index', '10.10.133.108', 'GET', '', '', '100', '2018-01-03 15:22:17', '2018-01-03 15:22:17', '00:00:00');
INSERT INTO `log_action` VALUES ('226', 'bijinshu', '/Home', '10.10.133.108', 'GET', '', '', '100', '2018-01-03 15:32:23', '2018-01-03 15:32:24', '00:00:01');
INSERT INTO `log_action` VALUES ('227', 'bijinshu', '/User/SignOut', '10.10.133.108', 'GET', '', '', '100', '2018-01-03 15:40:41', '2018-01-03 15:40:41', '00:00:00');
INSERT INTO `log_action` VALUES ('228', '', '/User/SignIn', '10.10.133.108', 'GET', '', '', '0', '2018-01-03 15:40:41', '2018-01-03 15:40:41', '00:00:00');
INSERT INTO `log_action` VALUES ('229', '', '/User/Register', '10.10.133.108', 'GET', '', '', '0', '2018-01-03 15:40:51', '2018-01-03 15:40:51', '00:00:00');
INSERT INTO `log_action` VALUES ('230', '', '/User/SignIn', '10.10.133.108', 'GET', '', '', '0', '2018-01-03 15:41:07', '2018-01-03 15:41:07', '00:00:01');
INSERT INTO `log_action` VALUES ('231', '', '/User/Register', '10.10.133.108', 'GET', '', '', '0', '2018-01-03 15:41:18', '2018-01-03 15:41:18', '00:00:01');
INSERT INTO `log_action` VALUES ('232', '', '/User/SignIn', '10.10.133.108', 'GET', '', '', '0', '2018-01-03 15:41:27', '2018-01-03 15:41:27', '00:00:00');
INSERT INTO `log_action` VALUES ('233', '', '/User/SignIn', '10.10.133.108', 'GET', '', '', '0', '2018-01-03 15:41:31', '2018-01-03 15:41:31', '00:00:00');
INSERT INTO `log_action` VALUES ('234', '', '/User/SignIn', '10.10.133.108', 'GET', '', '', '0', '2018-01-03 17:28:58', '2018-01-03 17:28:58', '00:00:01');
INSERT INTO `log_action` VALUES ('235', '', '/User/SignIn', '10.10.133.108', 'GET', '', '', '0', '2018-02-09 09:28:50', '2018-02-09 09:28:52', '00:00:03');
INSERT INTO `log_action` VALUES ('236', '', '/User/SignIn', '10.10.133.108', 'POST', '', '{\"UserName\":\"bijinshu\",\"Pwd\":\"40bd001563085fc35165329ea1ff5c5ecbdbbeef\"}', '0', '2018-02-09 09:28:59', null, null);
INSERT INTO `log_action` VALUES ('237', '', '/User/SignIn', '10.10.133.108', 'POST', '', '{\"UserName\":\"bijinshu\",\"Pwd\":\"40bd001563085fc35165329ea1ff5c5ecbdbbeef\"}', '0', '2018-02-09 09:30:02', '2018-02-09 09:30:06', '00:00:04');
INSERT INTO `log_action` VALUES ('238', '', '/User/SignIn', '10.10.133.108', 'POST', '成功', '{\"UserName\":\"bijinshu\",\"Pwd\":\"40bd001563085fc35165329ea1ff5c5ecbdbbeef\"}', '0', '2018-02-09 09:32:36', '2018-02-09 09:32:36', '00:00:00');
INSERT INTO `log_action` VALUES ('239', 'bijinshu', '/Home/Index', '10.10.133.108', 'GET', '', '', '100', '2018-02-09 09:32:37', '2018-02-09 09:32:37', '00:00:01');
INSERT INTO `log_action` VALUES ('240', 'bijinshu', '/Home/Index', '10.10.133.108', 'GET', '', '', '100', '2018-02-09 09:36:33', '2018-02-09 09:36:33', '00:00:00');
INSERT INTO `log_action` VALUES ('241', 'bijinshu', '/Home/Index', '10.10.133.108', 'GET', '', '', '100', '2018-02-09 09:36:36', '2018-02-09 09:36:37', '00:00:01');
INSERT INTO `log_action` VALUES ('242', '', '/User/SignIn', '10.10.133.108', 'GET', '', '', '0', '2018-02-09 10:47:17', '2018-02-09 10:47:18', '00:00:01');
INSERT INTO `log_action` VALUES ('243', '', '/User/SignIn', '10.10.133.108', 'POST', '成功', '{\"UserName\":\"bijinshu\",\"Pwd\":\"40bd001563085fc35165329ea1ff5c5ecbdbbeef\"}', '0', '2018-02-09 10:47:22', '2018-02-09 10:47:23', '00:00:02');
INSERT INTO `log_action` VALUES ('244', 'bijinshu', '/Home/Index', '10.10.133.108', 'GET', '', '', '100', '2018-02-09 10:47:23', '2018-02-09 10:47:23', '00:00:01');
INSERT INTO `log_action` VALUES ('245', '', '/User/SignIn', '10.10.133.108', 'GET', '', '', '0', '2018-02-09 10:49:41', '2018-02-09 10:49:42', '00:00:01');
INSERT INTO `log_action` VALUES ('246', 'bijinshu', '/User/SignIn', '10.10.133.108', 'GET', '', '', '100', '2018-02-09 10:49:52', '2018-02-09 10:49:52', '00:00:01');
INSERT INTO `log_action` VALUES ('247', 'bijinshu', '/User/SignIn', '10.10.133.108', 'POST', '成功', '{\"UserName\":\"bijinshu\",\"Pwd\":\"40bd001563085fc35165329ea1ff5c5ecbdbbeef\"}', '100', '2018-02-09 10:49:54', '2018-02-09 10:49:55', '00:00:02');
INSERT INTO `log_action` VALUES ('248', 'bijinshu', '/Home/Index', '10.10.133.108', 'GET', '', '', '100', '2018-02-09 10:49:55', '2018-02-09 10:49:55', '00:00:01');
INSERT INTO `log_action` VALUES ('249', 'bijinshu', '/Contact/Index', '10.10.133.108', 'GET', '', '', '100', '2018-02-09 10:50:03', '2018-02-09 10:50:03', '00:00:01');
INSERT INTO `log_action` VALUES ('250', 'bijinshu', '/Contact/Index', '10.10.133.108', 'POST', '成功', '{\"Name\":\"\",\"Area\":\"\",\"Address\":\"\",\"PageIndex\":\"0\",\"PageSize\":\"10\"}', '100', '2018-02-09 10:50:03', '2018-02-09 10:50:03', '00:00:00');
INSERT INTO `log_action` VALUES ('251', 'bijinshu', '/Contact/Index', '10.10.133.108', 'GET', '', '', '100', '2018-02-09 10:50:18', '2018-02-09 10:50:18', '00:00:00');
INSERT INTO `log_action` VALUES ('252', 'bijinshu', '/Contact/Index', '10.10.133.108', 'POST', '成功', '{\"Name\":\"\",\"Area\":\"\",\"Address\":\"\",\"PageIndex\":\"0\",\"PageSize\":\"10\"}', '100', '2018-02-09 10:50:18', '2018-02-09 10:50:18', '00:00:00');
INSERT INTO `log_action` VALUES ('253', 'bijinshu', '/Contact/Index', '10.10.133.108', 'GET', '', '', '100', '2018-02-09 11:35:03', '2018-02-09 11:35:03', '00:00:00');
INSERT INTO `log_action` VALUES ('254', 'bijinshu', '/Contact/Index', '10.10.133.108', 'POST', '成功', '{\"Name\":\"\",\"Area\":\"\",\"Address\":\"\",\"PageIndex\":\"0\",\"PageSize\":\"10\"}', '100', '2018-02-09 11:35:04', '2018-02-09 11:35:04', '00:00:01');
INSERT INTO `log_action` VALUES ('255', 'bijinshu', '/Contact/Index', '10.10.133.108', 'GET', '', '', '100', '2018-02-09 11:35:28', '2018-02-09 11:35:28', '00:00:01');
INSERT INTO `log_action` VALUES ('256', 'bijinshu', '/Contact/Index', '10.10.133.108', 'POST', '成功', '{\"Name\":\"\",\"Area\":\"\",\"Address\":\"\",\"PageIndex\":\"0\",\"PageSize\":\"10\"}', '100', '2018-02-09 11:35:28', '2018-02-09 11:35:28', '00:00:01');
INSERT INTO `log_action` VALUES ('257', 'bijinshu', '/Contact/Index', '10.10.133.108', 'GET', '', '', '100', '2018-02-09 11:35:32', '2018-02-09 11:35:32', '00:00:00');
INSERT INTO `log_action` VALUES ('258', 'bijinshu', '/Contact/Index', '10.10.133.108', 'POST', '成功', '{\"Name\":\"\",\"Area\":\"\",\"Address\":\"\",\"PageIndex\":\"0\",\"PageSize\":\"10\"}', '100', '2018-02-09 11:35:32', '2018-02-09 11:35:32', '00:00:00');
INSERT INTO `log_action` VALUES ('259', 'bijinshu', '/Contact/Index', '10.10.133.108', 'GET', '', '', '100', '2018-02-09 11:36:30', '2018-02-09 11:36:30', '00:00:01');
INSERT INTO `log_action` VALUES ('260', 'bijinshu', '/Contact/Index', '10.10.133.108', 'POST', '成功', '{\"Name\":\"\",\"Area\":\"\",\"Address\":\"\",\"PageIndex\":\"0\",\"PageSize\":\"10\"}', '100', '2018-02-09 11:36:30', '2018-02-09 11:36:30', '00:00:01');
INSERT INTO `log_action` VALUES ('261', 'bijinshu', '/Contact/Index', '10.10.133.108', 'GET', '', '', '100', '2018-02-09 11:36:31', '2018-02-09 11:36:31', '00:00:00');
INSERT INTO `log_action` VALUES ('262', 'bijinshu', '/Contact/Index', '10.10.133.108', 'POST', '成功', '{\"Name\":\"\",\"Area\":\"\",\"Address\":\"\",\"PageIndex\":\"0\",\"PageSize\":\"10\"}', '100', '2018-02-09 11:36:32', '2018-02-09 11:36:32', '00:00:01');
INSERT INTO `log_action` VALUES ('263', 'bijinshu', '/Contact/Index', '10.10.133.108', 'GET', '', '', '100', '2018-02-09 11:36:32', '2018-02-09 11:36:32', '00:00:00');
INSERT INTO `log_action` VALUES ('264', 'bijinshu', '/Contact/Index', '10.10.133.108', 'POST', '成功', '{\"Name\":\"\",\"Area\":\"\",\"Address\":\"\",\"PageIndex\":\"0\",\"PageSize\":\"10\"}', '100', '2018-02-09 11:36:32', '2018-02-09 11:36:32', '00:00:00');
INSERT INTO `log_action` VALUES ('265', 'bijinshu', '/Contact/Index', '10.10.133.108', 'GET', '', '', '100', '2018-02-09 11:36:33', '2018-02-09 11:36:33', '00:00:00');
INSERT INTO `log_action` VALUES ('266', 'bijinshu', '/Contact/Index', '10.10.133.108', 'POST', '成功', '{\"Name\":\"\",\"Area\":\"\",\"Address\":\"\",\"PageIndex\":\"0\",\"PageSize\":\"10\"}', '100', '2018-02-09 11:36:34', '2018-02-09 11:36:34', '00:00:01');
INSERT INTO `log_action` VALUES ('267', 'bijinshu', '/Contact/Index', '10.10.133.108', 'GET', '', '', '100', '2018-02-09 11:36:34', '2018-02-09 11:36:34', '00:00:01');
INSERT INTO `log_action` VALUES ('268', 'bijinshu', '/Contact/Index', '10.10.133.108', 'POST', '成功', '{\"Name\":\"\",\"Area\":\"\",\"Address\":\"\",\"PageIndex\":\"0\",\"PageSize\":\"10\"}', '100', '2018-02-09 11:36:34', '2018-02-09 11:36:34', '00:00:01');
INSERT INTO `log_action` VALUES ('269', 'bijinshu', '/Contact/Index', '10.10.133.108', 'GET', '', '', '100', '2018-02-09 11:36:35', '2018-02-09 11:36:35', '00:00:01');
INSERT INTO `log_action` VALUES ('270', 'bijinshu', '/Contact/Index', '10.10.133.108', 'POST', '成功', '{\"Name\":\"\",\"Area\":\"\",\"Address\":\"\",\"PageIndex\":\"0\",\"PageSize\":\"10\"}', '100', '2018-02-09 11:36:35', '2018-02-09 11:36:35', '00:00:01');
INSERT INTO `log_action` VALUES ('271', 'bijinshu', '/Contact/Index', '10.10.133.108', 'POST', '成功', '{\"Name\":\"\",\"Area\":\"\",\"Address\":\"\",\"PageIndex\":\"1\",\"PageSize\":\"10\"}', '100', '2018-02-09 11:37:01', '2018-02-09 11:37:01', '00:00:01');
INSERT INTO `log_action` VALUES ('272', 'bijinshu', '/Contact/Index', '10.10.133.108', 'POST', '成功', '{\"Name\":\"\",\"Area\":\"\",\"Address\":\"\",\"PageIndex\":\"2\",\"PageSize\":\"10\"}', '100', '2018-02-09 11:37:03', '2018-02-09 11:37:03', '00:00:01');
INSERT INTO `log_action` VALUES ('273', 'bijinshu', '/Contact/Index', '10.10.133.108', 'POST', '成功', '{\"Name\":\"\",\"Area\":\"\",\"Address\":\"\",\"PageIndex\":\"1\",\"PageSize\":\"10\"}', '100', '2018-02-09 11:37:04', '2018-02-09 11:37:04', '00:00:00');
INSERT INTO `log_action` VALUES ('274', 'bijinshu', '/Contact/Index', '10.10.133.108', 'POST', '成功', '{\"Name\":\"\",\"Area\":\"\",\"Address\":\"\",\"PageIndex\":\"0\",\"PageSize\":\"10\"}', '100', '2018-02-09 11:37:06', '2018-02-09 11:37:06', '00:00:01');
INSERT INTO `log_action` VALUES ('275', 'bijinshu', '/Contact/Index', '10.10.133.108', 'POST', '成功', '{\"Name\":\"\",\"Area\":\"\",\"Address\":\"\",\"PageIndex\":\"1\",\"PageSize\":\"10\"}', '100', '2018-02-09 11:37:07', '2018-02-09 11:37:07', '00:00:01');
INSERT INTO `log_action` VALUES ('276', 'bijinshu', '/Contact/Index', '10.10.133.108', 'POST', '成功', '{\"Name\":\"\",\"Area\":\"\",\"Address\":\"\",\"PageIndex\":\"2\",\"PageSize\":\"10\"}', '100', '2018-02-09 11:37:07', '2018-02-09 11:37:07', '00:00:00');
INSERT INTO `log_action` VALUES ('277', 'bijinshu', '/Home/Index', '10.10.133.108', 'GET', '', '', '100', '2018-02-09 11:37:18', '2018-02-09 11:37:18', '00:00:00');
INSERT INTO `log_action` VALUES ('278', 'bijinshu', '/Contact/Index', '10.10.133.108', 'GET', '', '', '100', '2018-02-09 11:37:41', '2018-02-09 11:37:41', '00:00:01');
INSERT INTO `log_action` VALUES ('279', 'bijinshu', '/Contact/Index', '10.10.133.108', 'POST', '成功', '{\"Name\":\"\",\"Area\":\"\",\"Address\":\"\",\"PageIndex\":\"0\",\"PageSize\":\"10\"}', '100', '2018-02-09 11:37:41', '2018-02-09 11:37:41', '00:00:01');
INSERT INTO `log_action` VALUES ('280', 'bijinshu', '/Home/Index', '10.10.133.108', 'GET', '', '', '100', '2018-02-09 11:38:32', '2018-02-09 11:38:32', '00:00:00');
INSERT INTO `log_action` VALUES ('281', 'bijinshu', '/Contact/Index', '10.10.133.108', 'GET', '', '', '100', '2018-02-09 11:46:29', '2018-02-09 11:46:29', '00:00:00');
INSERT INTO `log_action` VALUES ('282', 'bijinshu', '/Contact/Index', '10.10.133.108', 'POST', '成功', '{\"Name\":\"\",\"Area\":\"\",\"Address\":\"\",\"PageIndex\":\"0\",\"PageSize\":\"10\"}', '100', '2018-02-09 11:46:29', '2018-02-09 11:46:29', '00:00:00');
INSERT INTO `log_action` VALUES ('283', 'bijinshu', '/Home/Index', '10.10.133.108', 'GET', '', '', '100', '2018-02-09 11:47:20', '2018-02-09 11:47:20', '00:00:00');
INSERT INTO `log_action` VALUES ('284', 'bijinshu', '/Contact/Index', '10.10.133.108', 'GET', '', '', '100', '2018-02-09 11:47:29', '2018-02-09 11:47:29', '00:00:01');
INSERT INTO `log_action` VALUES ('285', 'bijinshu', '/Contact/Index', '10.10.133.108', 'POST', '成功', '{\"Name\":\"\",\"Area\":\"\",\"Address\":\"\",\"PageIndex\":\"0\",\"PageSize\":\"10\"}', '100', '2018-02-09 11:47:29', '2018-02-09 11:47:29', '00:00:01');
INSERT INTO `log_action` VALUES ('286', 'bijinshu', '/Contact/Index', '10.10.133.108', 'POST', '成功', '{\"Name\":\"\",\"Area\":\"\",\"Address\":\"\",\"PageIndex\":\"1\",\"PageSize\":\"10\"}', '100', '2018-02-09 11:49:27', '2018-02-09 11:49:27', '00:00:00');
INSERT INTO `log_action` VALUES ('287', 'bijinshu', '/Contact/Index', '10.10.133.108', 'POST', '成功', '{\"Name\":\"\",\"Area\":\"\",\"Address\":\"\",\"PageIndex\":\"2\",\"PageSize\":\"10\"}', '100', '2018-02-09 11:49:29', '2018-02-09 11:49:29', '00:00:01');
INSERT INTO `log_action` VALUES ('288', 'bijinshu', '/Contact/Index', '10.10.133.108', 'POST', '成功', '{\"Name\":\"\",\"Area\":\"\",\"Address\":\"\",\"PageIndex\":\"1\",\"PageSize\":\"10\"}', '100', '2018-02-09 11:49:30', '2018-02-09 11:49:30', '00:00:01');
INSERT INTO `log_action` VALUES ('289', 'bijinshu', '/Contact/Index', '10.10.133.108', 'POST', '成功', '{\"Name\":\"\",\"Area\":\"\",\"Address\":\"\",\"PageIndex\":\"0\",\"PageSize\":\"10\"}', '100', '2018-02-09 11:49:31', '2018-02-09 11:49:31', '00:00:00');
INSERT INTO `log_action` VALUES ('290', 'bijinshu', '/Contact/Index', '10.10.133.108', 'GET', '', '', '100', '2018-02-09 13:04:20', '2018-02-09 13:04:20', '00:00:01');
INSERT INTO `log_action` VALUES ('291', 'bijinshu', '/Contact/Index', '10.10.133.108', 'POST', '成功', '{\"Name\":\"\",\"Area\":\"\",\"Address\":\"\",\"PageIndex\":\"0\",\"PageSize\":\"10\"}', '100', '2018-02-09 13:04:23', '2018-02-09 13:04:24', '00:00:01');
INSERT INTO `log_action` VALUES ('292', 'bijinshu', '/Contact/Index', '10.10.133.108', 'GET', '', '', '100', '2018-02-09 13:04:57', '2018-02-09 13:04:57', '00:00:00');
INSERT INTO `log_action` VALUES ('293', 'bijinshu', '/Contact/Index', '10.10.133.108', 'POST', '成功', '{\"Name\":\"\",\"Area\":\"\",\"Address\":\"\",\"PageIndex\":\"0\",\"PageSize\":\"10\"}', '100', '2018-02-09 13:04:58', '2018-02-09 13:04:58', '00:00:01');
INSERT INTO `log_action` VALUES ('294', 'bijinshu', '/Contact/Index', '10.10.133.108', 'GET', '', '', '100', '2018-02-09 13:09:27', '2018-02-09 13:09:27', '00:00:01');
INSERT INTO `log_action` VALUES ('295', 'bijinshu', '/Contact/Index', '10.10.133.108', 'POST', '成功', '{\"Name\":\"\",\"Area\":\"\",\"Address\":\"\",\"PageIndex\":\"0\",\"PageSize\":\"10\"}', '100', '2018-02-09 13:09:27', '2018-02-09 13:09:27', '00:00:00');
INSERT INTO `log_action` VALUES ('296', 'bijinshu', '/Contact/Index', '10.10.133.108', 'GET', '', '', '100', '2018-02-09 13:09:32', '2018-02-09 13:09:32', '00:00:01');
INSERT INTO `log_action` VALUES ('297', 'bijinshu', '/Contact/Index', '10.10.133.108', 'POST', '成功', '{\"Name\":\"\",\"Area\":\"\",\"Address\":\"\",\"PageIndex\":\"0\",\"PageSize\":\"10\"}', '100', '2018-02-09 13:09:32', '2018-02-09 13:09:32', '00:00:01');
INSERT INTO `log_action` VALUES ('298', 'bijinshu', '/Contact/Index', '10.10.133.108', 'GET', '', '', '100', '2018-02-09 13:09:37', '2018-02-09 13:09:38', '00:00:01');
INSERT INTO `log_action` VALUES ('299', 'bijinshu', '/Contact/Index', '10.10.133.108', 'POST', '成功', '{\"Name\":\"\",\"Area\":\"\",\"Address\":\"\",\"PageIndex\":\"0\",\"PageSize\":\"10\"}', '100', '2018-02-09 13:09:38', '2018-02-09 13:09:38', '00:00:01');
INSERT INTO `log_action` VALUES ('300', 'bijinshu', '/Contact/Index', '10.10.133.108', 'GET', '', '', '100', '2018-02-09 13:12:34', '2018-02-09 13:12:34', '00:00:01');
INSERT INTO `log_action` VALUES ('301', 'bijinshu', '/Contact/Index', '10.10.133.108', 'POST', '成功', '{\"Name\":\"\",\"Area\":\"\",\"Address\":\"\",\"PageIndex\":\"0\",\"PageSize\":\"10\"}', '100', '2018-02-09 13:12:34', '2018-02-09 13:12:34', '00:00:01');
INSERT INTO `log_action` VALUES ('302', 'bijinshu', '/Contact/Index', '10.10.133.108', 'POST', '成功', '{\"Name\":\"\",\"Area\":\"\",\"Address\":\"\",\"PageIndex\":\"1\",\"PageSize\":\"10\"}', '100', '2018-02-09 13:12:38', '2018-02-09 13:12:39', '00:00:01');
INSERT INTO `log_action` VALUES ('303', 'bijinshu', '/Contact/Index', '10.10.133.108', 'POST', '成功', '{\"Name\":\"\",\"Area\":\"\",\"Address\":\"\",\"PageIndex\":\"2\",\"PageSize\":\"10\"}', '100', '2018-02-09 13:12:40', '2018-02-09 13:12:40', '00:00:01');
INSERT INTO `log_action` VALUES ('304', 'bijinshu', '/Contact/Index', '10.10.133.108', 'GET', '', '', '100', '2018-02-09 13:15:11', '2018-02-09 13:15:11', '00:00:00');
INSERT INTO `log_action` VALUES ('305', 'bijinshu', '/Contact/Index', '10.10.133.108', 'POST', '成功', '{\"Name\":\"\",\"Area\":\"\",\"Address\":\"\",\"PageIndex\":\"0\",\"PageSize\":\"10\"}', '100', '2018-02-09 13:15:11', '2018-02-09 13:15:11', '00:00:00');
INSERT INTO `log_action` VALUES ('306', 'bijinshu', '/Contact/Index', '10.10.133.108', 'POST', '成功', '{\"Name\":\"\",\"Area\":\"\",\"Address\":\"\",\"PageIndex\":\"1\",\"PageSize\":\"10\"}', '100', '2018-02-09 13:15:58', '2018-02-09 13:15:58', '00:00:00');
INSERT INTO `log_action` VALUES ('307', 'bijinshu', '/Contact/Index', '10.10.133.108', 'POST', '成功', '{\"Name\":\"\",\"Area\":\"\",\"Address\":\"\",\"PageIndex\":\"2\",\"PageSize\":\"10\"}', '100', '2018-02-09 13:15:59', '2018-02-09 13:16:00', '00:00:01');
INSERT INTO `log_action` VALUES ('308', 'bijinshu', '/Home/Index', '10.10.133.108', 'GET', '', '', '100', '2018-02-09 13:19:45', '2018-02-09 13:19:45', '00:00:01');
INSERT INTO `log_action` VALUES ('309', 'bijinshu', '/Contact/Index', '10.10.133.108', 'GET', '', '', '100', '2018-02-09 13:19:57', '2018-02-09 13:19:57', '00:00:00');
INSERT INTO `log_action` VALUES ('310', 'bijinshu', '/Contact/Index', '10.10.133.108', 'POST', '成功', '{\"Name\":\"\",\"Area\":\"\",\"Address\":\"\",\"PageIndex\":\"0\",\"PageSize\":\"10\"}', '100', '2018-02-09 13:19:57', '2018-02-09 13:19:57', '00:00:00');
INSERT INTO `log_action` VALUES ('311', 'bijinshu', '/Contact/Index', '10.10.133.108', 'GET', '', '', '100', '2018-02-09 13:20:24', '2018-02-09 13:20:24', '00:00:01');
INSERT INTO `log_action` VALUES ('312', 'bijinshu', '/Contact/Index', '10.10.133.108', 'POST', '成功', '{\"Name\":\"\",\"Area\":\"\",\"Address\":\"\",\"PageIndex\":\"0\",\"PageSize\":\"10\"}', '100', '2018-02-09 13:20:24', '2018-02-09 13:20:24', '00:00:00');
INSERT INTO `log_action` VALUES ('313', 'bijinshu', '/Contact/Index', '10.10.133.108', 'GET', '', '', '100', '2018-02-09 13:20:27', '2018-02-09 13:20:27', '00:00:00');
INSERT INTO `log_action` VALUES ('314', 'bijinshu', '/Contact/Index', '10.10.133.108', 'POST', '成功', '{\"Name\":\"\",\"Area\":\"\",\"Address\":\"\",\"PageIndex\":\"0\",\"PageSize\":\"10\"}', '100', '2018-02-09 13:20:27', '2018-02-09 13:20:27', '00:00:00');
INSERT INTO `log_action` VALUES ('315', 'bijinshu', '/Contact/Index', '10.10.133.108', 'GET', '', '', '100', '2018-02-09 13:20:34', '2018-02-09 13:20:34', '00:00:00');
INSERT INTO `log_action` VALUES ('316', 'bijinshu', '/Contact/Index', '10.10.133.108', 'POST', '成功', '{\"Name\":\"\",\"Area\":\"\",\"Address\":\"\",\"PageIndex\":\"0\",\"PageSize\":\"10\"}', '100', '2018-02-09 13:20:34', '2018-02-09 13:20:34', '00:00:00');
INSERT INTO `log_action` VALUES ('317', 'bijinshu', '/Contact/Index', '10.10.133.108', 'GET', '', '', '100', '2018-02-09 13:20:35', '2018-02-09 13:20:35', '00:00:00');
INSERT INTO `log_action` VALUES ('318', 'bijinshu', '/Contact/Index', '10.10.133.108', 'POST', '成功', '{\"Name\":\"\",\"Area\":\"\",\"Address\":\"\",\"PageIndex\":\"0\",\"PageSize\":\"10\"}', '100', '2018-02-09 13:20:35', '2018-02-09 13:20:35', '00:00:00');
INSERT INTO `log_action` VALUES ('319', 'bijinshu', '/Contact/Index', '10.10.133.108', 'GET', '', '', '100', '2018-02-09 13:20:37', '2018-02-09 13:20:37', '00:00:01');
INSERT INTO `log_action` VALUES ('320', 'bijinshu', '/Contact/Index', '10.10.133.108', 'POST', '成功', '{\"Name\":\"\",\"Area\":\"\",\"Address\":\"\",\"PageIndex\":\"0\",\"PageSize\":\"10\"}', '100', '2018-02-09 13:20:37', '2018-02-09 13:20:37', '00:00:00');
INSERT INTO `log_action` VALUES ('321', '', '/User/SignIn', '10.10.133.108', 'GET', '', '', '0', '2018-02-11 10:27:48', '2018-02-11 10:27:49', '00:00:01');
INSERT INTO `log_action` VALUES ('322', '', '/User/SignIn', '10.10.133.108', 'POST', '', '{\"UserName\":\"bijinshu\",\"Pwd\":\"40bd001563085fc35165329ea1ff5c5ecbdbbeef\"}', '0', '2018-02-11 10:27:58', null, null);
INSERT INTO `log_action` VALUES ('323', '', '/User/SignIn', '10.10.133.108', 'GET', '', '', '0', '2018-02-11 10:30:11', '2018-02-11 10:30:12', '00:00:01');
INSERT INTO `log_action` VALUES ('324', '', '/User/SignIn', '10.10.133.108', 'POST', '', '{\"UserName\":\"bijinshu\",\"Pwd\":\"40bd001563085fc35165329ea1ff5c5ecbdbbeef\"}', '0', '2018-02-11 10:30:41', '2018-02-11 10:31:24', '00:00:44');
INSERT INTO `log_action` VALUES ('325', '', '/User/SignIn', '10.10.133.108', 'POST', '成功', '{\"UserName\":\"bijinshu\",\"Pwd\":\"40bd001563085fc35165329ea1ff5c5ecbdbbeef\"}', '0', '2018-02-11 10:31:29', '2018-02-11 10:31:29', '00:00:01');
INSERT INTO `log_action` VALUES ('326', 'bijinshu', '/Home/Index', '10.10.133.108', 'GET', '', '', '100', '2018-02-11 10:31:29', '2018-02-11 10:31:29', '00:00:00');
INSERT INTO `log_action` VALUES ('327', 'bijinshu', '/Contact/Index', '10.10.133.108', 'GET', '', '', '100', '2018-02-11 10:32:13', '2018-02-11 10:32:13', '00:00:00');
INSERT INTO `log_action` VALUES ('328', 'bijinshu', '/Contact/Index', '10.10.133.108', 'POST', '成功', '{\"Name\":\"\",\"Area\":\"\",\"Address\":\"\",\"PageIndex\":\"0\",\"PageSize\":\"10\"}', '100', '2018-02-11 10:32:14', '2018-02-11 10:32:14', '00:00:01');
INSERT INTO `log_action` VALUES ('329', 'bijinshu', '/Home/Index', '10.10.133.108', 'GET', '', '', '100', '2018-02-11 10:34:48', '2018-02-11 10:34:49', '00:00:01');
INSERT INTO `log_action` VALUES ('330', 'bijinshu', '/Contact/Index', '10.10.133.108', 'GET', '', '', '100', '2018-02-11 10:34:57', '2018-02-11 10:34:57', '00:00:00');
INSERT INTO `log_action` VALUES ('331', 'bijinshu', '/Contact/Index', '10.10.133.108', 'POST', '成功', '{\"Name\":\"\",\"Area\":\"\",\"Address\":\"\",\"PageIndex\":\"0\",\"PageSize\":\"10\"}', '100', '2018-02-11 10:34:57', '2018-02-11 10:34:57', '00:00:00');
INSERT INTO `log_action` VALUES ('332', 'bijinshu', '/Contact/Index', '10.10.133.108', 'POST', '成功', '{\"Name\":\"\",\"Area\":\"\",\"Address\":\"\",\"PageIndex\":\"1\",\"PageSize\":\"10\"}', '100', '2018-02-11 10:35:12', '2018-02-11 10:35:12', '00:00:01');
INSERT INTO `log_action` VALUES ('333', 'bijinshu', '/Contact/Index', '10.10.133.108', 'POST', '成功', '{\"Name\":\"\",\"Area\":\"\",\"Address\":\"\",\"PageIndex\":\"2\",\"PageSize\":\"10\"}', '100', '2018-02-11 10:35:13', '2018-02-11 10:35:13', '00:00:01');
INSERT INTO `log_action` VALUES ('334', 'bijinshu', '/Contact/Index', '10.10.133.108', 'POST', '成功', '{\"Name\":\"\",\"Area\":\"\",\"Address\":\"\",\"PageIndex\":\"1\",\"PageSize\":\"10\"}', '100', '2018-02-11 10:35:14', '2018-02-11 10:35:14', '00:00:01');
INSERT INTO `log_action` VALUES ('335', 'bijinshu', '/Contact/Index', '10.10.133.108', 'POST', '成功', '{\"Name\":\"\",\"Area\":\"\",\"Address\":\"\",\"PageIndex\":\"0\",\"PageSize\":\"10\"}', '100', '2018-02-11 10:35:15', '2018-02-11 10:35:15', '00:00:01');
INSERT INTO `log_action` VALUES ('336', 'bijinshu', '/Contact/Index', '10.10.133.108', 'POST', '成功', '{\"Name\":\"\",\"Area\":\"\",\"Address\":\"\",\"PageIndex\":\"1\",\"PageSize\":\"10\"}', '100', '2018-02-11 10:35:40', '2018-02-11 10:35:40', '00:00:01');
INSERT INTO `log_action` VALUES ('337', 'bijinshu', '/Contact/Index', '10.10.133.108', 'POST', '成功', '{\"Name\":\"\",\"Area\":\"\",\"Address\":\"\",\"PageIndex\":\"0\",\"PageSize\":\"10\"}', '100', '2018-02-11 10:35:42', '2018-02-11 10:35:42', '00:00:01');
INSERT INTO `log_action` VALUES ('338', 'bijinshu', '/Contact/Edit', '10.10.133.108', 'POST', '', '{\"Id\":\"1\",\"ContactName\":\"张海川\",\"Mobile\":\"15801992799\",\"Address\":\"中国江苏省南京市雨花台区雨花南路4号-10号 邮政编码: 210012\",\"QQ\":\"914023961\",\"Email\":\"bijinshu@163.com\",\"Remark\":\"\"}', '100', '2018-02-11 10:35:47', null, null);
INSERT INTO `log_action` VALUES ('339', 'bijinshu', '/', '10.10.133.108', 'GET', '', '', '100', '2018-02-11 10:38:04', '2018-02-11 10:38:04', '00:00:01');
INSERT INTO `log_action` VALUES ('340', 'bijinshu', '/Contact/Edit', '10.10.133.108', 'POST', '成功', '{\"Id\":\"1\",\"ContactName\":\"张海川\",\"Mobile\":\"15801992799\",\"Address\":\"中国江苏省南京市雨花台区雨花南路4号-10号 邮政编码: 210012\",\"QQ\":\"914023961\",\"Email\":\"bijinshu@163.com\",\"Remark\":\"\"}', '100', '2018-02-11 10:38:14', '2018-02-11 10:38:14', '00:00:00');
INSERT INTO `log_action` VALUES ('341', 'bijinshu', '/Contact/Index', '10.10.133.108', 'POST', '成功', '{\"Name\":\"\",\"Area\":\"\",\"Address\":\"\",\"PageIndex\":\"0\",\"PageSize\":\"10\"}', '100', '2018-02-11 10:38:15', '2018-02-11 10:38:15', '00:00:01');
INSERT INTO `log_action` VALUES ('342', 'bijinshu', '/Contact/Index', '10.10.133.108', 'GET', '', '', '100', '2018-02-11 10:40:04', '2018-02-11 10:40:04', '00:00:00');
INSERT INTO `log_action` VALUES ('343', 'bijinshu', '/Contact/Index', '10.10.133.108', 'POST', '成功', '{\"Name\":\"\",\"Area\":\"\",\"Address\":\"\",\"PageIndex\":\"0\",\"PageSize\":\"10\"}', '100', '2018-02-11 10:40:07', '2018-02-11 10:40:07', '00:00:01');
INSERT INTO `log_action` VALUES ('344', 'bijinshu', '/Contact/Index', '10.10.133.108', 'GET', '', '', '100', '2018-02-11 10:40:08', '2018-02-11 10:40:08', '00:00:00');
INSERT INTO `log_action` VALUES ('345', 'bijinshu', '/Contact/Index', '10.10.133.108', 'POST', '成功', '{\"Name\":\"\",\"Area\":\"\",\"Address\":\"\",\"PageIndex\":\"0\",\"PageSize\":\"10\"}', '100', '2018-02-11 10:40:08', '2018-02-11 10:40:08', '00:00:00');
INSERT INTO `log_action` VALUES ('346', 'bijinshu', '/Contact/Index', '10.10.133.108', 'GET', '', '', '100', '2018-02-11 10:40:10', '2018-02-11 10:40:10', '00:00:01');
INSERT INTO `log_action` VALUES ('347', 'bijinshu', '/Contact/Index', '10.10.133.108', 'POST', '成功', '{\"Name\":\"\",\"Area\":\"\",\"Address\":\"\",\"PageIndex\":\"0\",\"PageSize\":\"10\"}', '100', '2018-02-11 10:40:10', '2018-02-11 10:40:10', '00:00:01');
INSERT INTO `log_action` VALUES ('348', 'bijinshu', '/Contact/Index', '10.10.133.108', 'GET', '', '', '100', '2018-02-11 10:40:12', '2018-02-11 10:40:12', '00:00:00');
INSERT INTO `log_action` VALUES ('349', 'bijinshu', '/Contact/Index', '10.10.133.108', 'POST', '成功', '{\"Name\":\"\",\"Area\":\"\",\"Address\":\"\",\"PageIndex\":\"0\",\"PageSize\":\"10\"}', '100', '2018-02-11 10:40:12', '2018-02-11 10:40:12', '00:00:00');
INSERT INTO `log_action` VALUES ('350', 'bijinshu', '/Contact/Index', '10.10.133.108', 'GET', '', '', '100', '2018-02-11 10:40:14', '2018-02-11 10:40:14', '00:00:01');
INSERT INTO `log_action` VALUES ('351', 'bijinshu', '/Contact/Index', '10.10.133.108', 'POST', '成功', '{\"Name\":\"\",\"Area\":\"\",\"Address\":\"\",\"PageIndex\":\"0\",\"PageSize\":\"10\"}', '100', '2018-02-11 10:40:14', '2018-02-11 10:40:14', '00:00:00');
INSERT INTO `log_action` VALUES ('352', 'bijinshu', '/Contact/Index', '10.10.133.108', 'POST', '成功', '{\"Name\":\"\",\"Area\":\"\",\"Address\":\"\",\"PageIndex\":\"1\",\"PageSize\":\"10\"}', '100', '2018-02-11 10:40:57', '2018-02-11 10:40:58', '00:00:01');
INSERT INTO `log_action` VALUES ('353', 'bijinshu', '/Contact/Index', '10.10.133.108', 'POST', '成功', '{\"Name\":\"\",\"Area\":\"\",\"Address\":\"\",\"PageIndex\":\"2\",\"PageSize\":\"10\"}', '100', '2018-02-11 10:41:01', '2018-02-11 10:41:01', '00:00:01');
INSERT INTO `log_action` VALUES ('354', 'bijinshu', '/Contact/Index', '10.10.133.108', 'POST', '成功', '{\"Name\":\"\",\"Area\":\"\",\"Address\":\"\",\"PageIndex\":\"1\",\"PageSize\":\"10\"}', '100', '2018-02-11 10:41:02', '2018-02-11 10:41:03', '00:00:01');
INSERT INTO `log_action` VALUES ('355', 'bijinshu', '/Contact/Index', '10.10.133.108', 'POST', '成功', '{\"Name\":\"\",\"Area\":\"\",\"Address\":\"\",\"PageIndex\":\"0\",\"PageSize\":\"10\"}', '100', '2018-02-11 10:41:04', '2018-02-11 10:41:04', '00:00:00');
INSERT INTO `log_action` VALUES ('356', 'bijinshu', '/User/SignIn', '10.10.133.108', 'GET', '', '', '100', '2018-02-11 16:39:16', '2018-02-11 16:39:17', '00:00:01');
INSERT INTO `log_action` VALUES ('357', 'bijinshu', '/User/SignIn', '10.10.133.108', 'GET', '', '', '100', '2018-02-11 16:42:58', '2018-02-11 16:42:59', '00:00:01');
INSERT INTO `log_action` VALUES ('358', 'bijinshu', '/User/SignOut', '10.10.133.108', 'GET', '', '', '100', '2018-02-12 17:01:43', '2018-02-12 17:01:43', '00:00:01');
INSERT INTO `log_action` VALUES ('359', '', '/User/Register', '10.10.133.108', 'GET', '', '', '0', '2018-02-12 17:23:14', '2018-02-12 17:23:14', '00:00:01');
INSERT INTO `log_action` VALUES ('360', '', '/User/Register', '10.10.133.108', 'GET', '', '', '0', '2018-02-12 17:40:03', '2018-02-12 17:40:04', '00:00:01');
INSERT INTO `log_action` VALUES ('361', '', '/User/Register', '10.10.133.108', 'GET', '', '', '0', '2018-02-12 17:40:09', '2018-02-12 17:40:09', '00:00:01');
INSERT INTO `log_action` VALUES ('362', '', '/User/Register', '10.10.133.108', 'GET', '', '', '0', '2018-02-12 17:40:12', '2018-02-12 17:40:12', '00:00:01');
INSERT INTO `log_action` VALUES ('363', '', '/User/Register', '10.10.133.108', 'GET', '', '', '0', '2018-02-12 17:40:42', '2018-02-12 17:40:42', '00:00:01');
INSERT INTO `log_action` VALUES ('364', 'bijinshu', '/User/New', '10.10.133.108', 'POST', '成功', '{\"Id\":\"0\",\"UserName\":\"ssss\",\"Pwd\":\"c455582f41f589213a7d34ccb3954c67476077da\",\"RealName\":\"当对方\",\"Gender\":\"男\",\"Mobile\":\"15648762587\",\"QQ\":\"\",\"Weixin\":\"\",\"Email\":\"\",\"Status\":\"0\",\"Remark\":\"\"}', '100', '2018-02-12 18:07:24', '2018-02-12 18:07:25', '00:00:01');

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
) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of log_exception
-- ----------------------------
INSERT INTO `log_exception` VALUES ('3', '/Home/Index', '', '未将对象引用设置到对象的实例。\r\n', '   在 ASP._Page_Views_Shared__Layout_cshtml.Execute() 位置 d:\\github.GrainManage\\GrainManage.Web\\Views\\Shared\\_Layout.cshtml:行号 7\r\n   在 System.Web.WebPages.WebPageBase.ExecutePageHierarchy()\r\n   在 System.Web.Mvc.WebViewPage.ExecutePageHierarchy()\r\n   在 System.Web.WebPages.WebPageBase.ExecutePageHierarchy(WebPageContext pageContext, TextWriter writer, WebPageRenderingBase startPage)\r\n   在 System.Web.WebPages.WebPageBase.<>c__DisplayClass3.<RenderPageCore>b__2(TextWriter writer)\r\n   在 System.Web.WebPages.HelperResult.WriteTo(TextWriter writer)\r\n   在 System.Web.WebPages.WebPageBase.Write(HelperResult result)\r\n   在 System.Web.WebPages.WebPageBase.RenderSurrounding(String partialViewName, Action`1 body)\r\n   在 System.Web.WebPages.WebPageBase.PopContext()\r\n   在 System.Web.WebPages.WebPageBase.ExecutePageHierarchy(WebPageContext pageContext, TextWriter writer, WebPageRenderingBase startPage)\r\n   在 System.Web.Mvc.RazorView.RenderView(ViewContext viewContext, TextWriter writer, Object instance)\r\n   在 System.Web.Mvc.BuildManagerCompiledView.Render(ViewContext viewContext, TextWriter writer)\r\n   在 System.Web.Mvc.ViewResultBase.ExecuteResult(ControllerContext context)\r\n   在 System.Web.Mvc.ControllerActionInvoker.InvokeActionResult(ControllerContext controllerContext, ActionResult actionResult)\r\n   在 System.Web.Mvc.ControllerActionInvoker.InvokeActionResultFilterRecursive(IList`1 filters, Int32 filterIndex, ResultExecutingContext preContext, ControllerContext controllerContext, ActionResult actionResult)\r\n   在 System.Web.Mvc.ControllerActionInvoker.InvokeActionResultFilterRecursive(IList`1 filters, Int32 filterIndex, ResultExecutingContext preContext, ControllerContext controllerContext, ActionResult actionResult)\r\n   在 System.Web.Mvc.ControllerActionInvoker.InvokeActionResultFilterRecursive(IList`1 filters, Int32 filterIndex, ResultExecutingContext preContext, ControllerContext controllerContext, ActionResult actionResult)\r\n   在 System.Web.Mvc.ControllerActionInvoker.InvokeActionResultWithFilters(ControllerContext controllerContext, IList`1 filters, ActionResult actionResult)\r\n   在 System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass21.<>c__DisplayClass2b.<BeginInvokeAction>b__1c()\r\n   在 System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass21.<BeginInvokeAction>b__1e(IAsyncResult asyncResult)', '10.10.133.209', '2017-08-29 13:52:43');
INSERT INTO `log_exception` VALUES ('4', '/Home/Index', '', '未将对象引用设置到对象的实例。\r\n', '   在 CallSite.Target(Closure , CallSite , List`1 , Object )\r\n   在 System.Dynamic.UpdateDelegates.UpdateAndExecute2[T0,T1,TRet](CallSite site, T0 arg0, T1 arg1)\r\n   在 GrainManage.Web.Common.TreeUtil.<>c__DisplayClass2_0.<RemoveNotValid>b__0(Tree s) 位置 D:\\github.GrainManage\\GrainManage.Web\\Common\\TreeUtil.cs:行号 68\r\n   在 System.Collections.Generic.List`1.RemoveAll(Predicate`1 match)\r\n   在 GrainManage.Web.Common.TreeUtil.RemoveNotValid(List`1 currentTreeList, List`1 allValidIdList) 位置 D:\\github.GrainManage\\GrainManage.Web\\Common\\TreeUtil.cs:行号 68\r\n   在 ASP._Page_Views_Shared__Layout_cshtml.Execute() 位置 d:\\github.GrainManage\\GrainManage.Web\\Views\\Shared\\_Layout.cshtml:行号 9\r\n   在 System.Web.WebPages.WebPageBase.ExecutePageHierarchy()\r\n   在 System.Web.Mvc.WebViewPage.ExecutePageHierarchy()\r\n   在 System.Web.WebPages.WebPageBase.ExecutePageHierarchy(WebPageContext pageContext, TextWriter writer, WebPageRenderingBase startPage)\r\n   在 System.Web.WebPages.WebPageBase.<>c__DisplayClass3.<RenderPageCore>b__2(TextWriter writer)\r\n   在 System.Web.WebPages.HelperResult.WriteTo(TextWriter writer)\r\n   在 System.Web.WebPages.WebPageBase.Write(HelperResult result)\r\n   在 System.Web.WebPages.WebPageBase.RenderSurrounding(String partialViewName, Action`1 body)\r\n   在 System.Web.WebPages.WebPageBase.PopContext()\r\n   在 System.Web.WebPages.WebPageBase.ExecutePageHierarchy(WebPageContext pageContext, TextWriter writer, WebPageRenderingBase startPage)\r\n   在 System.Web.Mvc.RazorView.RenderView(ViewContext viewContext, TextWriter writer, Object instance)\r\n   在 System.Web.Mvc.BuildManagerCompiledView.Render(ViewContext viewContext, TextWriter writer)\r\n   在 System.Web.Mvc.ViewResultBase.ExecuteResult(ControllerContext context)\r\n   在 System.Web.Mvc.ControllerActionInvoker.InvokeActionResult(ControllerContext controllerContext, ActionResult actionResult)\r\n   在 System.Web.Mvc.ControllerActionInvoker.InvokeActionResultFilterRecursive(IList`1 filters, Int32 filterIndex, ResultExecutingContext preContext, ControllerContext controllerContext, ActionResult actionResult)\r\n   在 System.Web.Mvc.ControllerActionInvoker.InvokeActionResultFilterRecursive(IList`1 filters, Int32 filterIndex, ResultExecutingContext preContext, ControllerContext controllerContext, ActionResult actionResult)\r\n   在 System.Web.Mvc.ControllerActionInvoker.InvokeActionResultFilterRecursive(IList`1 filters, Int32 filterIndex, ResultExecutingContext preContext, ControllerContext controllerContext, ActionResult actionResult)\r\n   在 System.Web.Mvc.ControllerActionInvoker.InvokeActionResultWithFilters(ControllerContext controllerContext, IList`1 filters, ActionResult actionResult)\r\n   在 System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass21.<>c__DisplayClass2b.<BeginInvokeAction>b__1c()\r\n   在 System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass21.<BeginInvokeAction>b__1e(IAsyncResult asyncResult)', '10.10.133.209', '2017-08-29 13:53:46');
INSERT INTO `log_exception` VALUES ('5', '/Home/Index', '', '未将对象引用设置到对象的实例。\r\n', '   在 CallSite.Target(Closure , CallSite , List`1 , Object )\r\n   在 System.Dynamic.UpdateDelegates.UpdateAndExecute2[T0,T1,TRet](CallSite site, T0 arg0, T1 arg1)\r\n   在 GrainManage.Web.Common.TreeUtil.<>c__DisplayClass2_0.<RemoveNotValid>b__0(Tree s) 位置 D:\\github.GrainManage\\GrainManage.Web\\Common\\TreeUtil.cs:行号 68\r\n   在 System.Collections.Generic.List`1.RemoveAll(Predicate`1 match)\r\n   在 GrainManage.Web.Common.TreeUtil.RemoveNotValid(List`1 currentTreeList, List`1 allValidIdList) 位置 D:\\github.GrainManage\\GrainManage.Web\\Common\\TreeUtil.cs:行号 68\r\n   在 ASP._Page_Views_Shared__Layout_cshtml.Execute() 位置 d:\\github.GrainManage\\GrainManage.Web\\Views\\Shared\\_Layout.cshtml:行号 9\r\n   在 System.Web.WebPages.WebPageBase.ExecutePageHierarchy()\r\n   在 System.Web.Mvc.WebViewPage.ExecutePageHierarchy()\r\n   在 System.Web.WebPages.WebPageBase.ExecutePageHierarchy(WebPageContext pageContext, TextWriter writer, WebPageRenderingBase startPage)\r\n   在 System.Web.WebPages.WebPageBase.<>c__DisplayClass3.<RenderPageCore>b__2(TextWriter writer)\r\n   在 System.Web.WebPages.HelperResult.WriteTo(TextWriter writer)\r\n   在 System.Web.WebPages.WebPageBase.Write(HelperResult result)\r\n   在 System.Web.WebPages.WebPageBase.RenderSurrounding(String partialViewName, Action`1 body)\r\n   在 System.Web.WebPages.WebPageBase.PopContext()\r\n   在 System.Web.WebPages.WebPageBase.ExecutePageHierarchy(WebPageContext pageContext, TextWriter writer, WebPageRenderingBase startPage)\r\n   在 System.Web.Mvc.RazorView.RenderView(ViewContext viewContext, TextWriter writer, Object instance)\r\n   在 System.Web.Mvc.BuildManagerCompiledView.Render(ViewContext viewContext, TextWriter writer)\r\n   在 System.Web.Mvc.ViewResultBase.ExecuteResult(ControllerContext context)\r\n   在 System.Web.Mvc.ControllerActionInvoker.InvokeActionResult(ControllerContext controllerContext, ActionResult actionResult)\r\n   在 System.Web.Mvc.ControllerActionInvoker.InvokeActionResultFilterRecursive(IList`1 filters, Int32 filterIndex, ResultExecutingContext preContext, ControllerContext controllerContext, ActionResult actionResult)\r\n   在 System.Web.Mvc.ControllerActionInvoker.InvokeActionResultFilterRecursive(IList`1 filters, Int32 filterIndex, ResultExecutingContext preContext, ControllerContext controllerContext, ActionResult actionResult)\r\n   在 System.Web.Mvc.ControllerActionInvoker.InvokeActionResultFilterRecursive(IList`1 filters, Int32 filterIndex, ResultExecutingContext preContext, ControllerContext controllerContext, ActionResult actionResult)\r\n   在 System.Web.Mvc.ControllerActionInvoker.InvokeActionResultWithFilters(ControllerContext controllerContext, IList`1 filters, ActionResult actionResult)\r\n   在 System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass21.<>c__DisplayClass2b.<BeginInvokeAction>b__1c()\r\n   在 System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass21.<BeginInvokeAction>b__1e(IAsyncResult asyncResult)', '10.10.133.209', '2017-08-29 14:01:52');
INSERT INTO `log_exception` VALUES ('6', '/Contact/Index', '', '找不到方法:“System.String GrainManage.Web.HttpUtil.GetUrl(System.String)”。\r\n', '   在 ASP._Page_Views_Contact_Index_cshtml.Execute()\r\n   在 System.Web.WebPages.WebPageBase.ExecutePageHierarchy()\r\n   在 System.Web.Mvc.WebViewPage.ExecutePageHierarchy()\r\n   在 System.Web.WebPages.StartPage.RunPage()\r\n   在 System.Web.WebPages.StartPage.ExecutePageHierarchy()\r\n   在 System.Web.WebPages.WebPageBase.ExecutePageHierarchy(WebPageContext pageContext, TextWriter writer, WebPageRenderingBase startPage)\r\n   在 System.Web.Mvc.RazorView.RenderView(ViewContext viewContext, TextWriter writer, Object instance)\r\n   在 System.Web.Mvc.BuildManagerCompiledView.Render(ViewContext viewContext, TextWriter writer)\r\n   在 System.Web.Mvc.ViewResultBase.ExecuteResult(ControllerContext context)\r\n   在 System.Web.Mvc.ControllerActionInvoker.InvokeActionResult(ControllerContext controllerContext, ActionResult actionResult)\r\n   在 System.Web.Mvc.ControllerActionInvoker.InvokeActionResultFilterRecursive(IList`1 filters, Int32 filterIndex, ResultExecutingContext preContext, ControllerContext controllerContext, ActionResult actionResult)\r\n   在 System.Web.Mvc.ControllerActionInvoker.InvokeActionResultFilterRecursive(IList`1 filters, Int32 filterIndex, ResultExecutingContext preContext, ControllerContext controllerContext, ActionResult actionResult)\r\n   在 System.Web.Mvc.ControllerActionInvoker.InvokeActionResultFilterRecursive(IList`1 filters, Int32 filterIndex, ResultExecutingContext preContext, ControllerContext controllerContext, ActionResult actionResult)\r\n   在 System.Web.Mvc.ControllerActionInvoker.InvokeActionResultWithFilters(ControllerContext controllerContext, IList`1 filters, ActionResult actionResult)\r\n   在 System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass21.<>c__DisplayClass2b.<BeginInvokeAction>b__1c()\r\n   在 System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass21.<BeginInvokeAction>b__1e(IAsyncResult asyncResult)', '10.10.133.209', '2017-08-29 14:51:50');
INSERT INTO `log_exception` VALUES ('7', '/Contact/Index', '', '未将对象引用设置到对象的实例。\r\n', '   在 ASP._Page_Views_Shared__Layout_cshtml.Execute() 位置 d:\\github.GrainManage\\GrainManage.Web\\Views\\Shared\\_Layout.cshtml:行号 7\r\n   在 System.Web.WebPages.WebPageBase.ExecutePageHierarchy()\r\n   在 System.Web.Mvc.WebViewPage.ExecutePageHierarchy()\r\n   在 System.Web.WebPages.WebPageBase.ExecutePageHierarchy(WebPageContext pageContext, TextWriter writer, WebPageRenderingBase startPage)\r\n   在 System.Web.WebPages.WebPageBase.<>c__DisplayClass3.<RenderPageCore>b__2(TextWriter writer)\r\n   在 System.Web.WebPages.HelperResult.WriteTo(TextWriter writer)\r\n   在 System.Web.WebPages.WebPageBase.Write(HelperResult result)\r\n   在 System.Web.WebPages.WebPageBase.RenderSurrounding(String partialViewName, Action`1 body)\r\n   在 System.Web.WebPages.WebPageBase.PopContext()\r\n   在 System.Web.WebPages.WebPageBase.ExecutePageHierarchy(WebPageContext pageContext, TextWriter writer, WebPageRenderingBase startPage)\r\n   在 System.Web.Mvc.RazorView.RenderView(ViewContext viewContext, TextWriter writer, Object instance)\r\n   在 System.Web.Mvc.BuildManagerCompiledView.Render(ViewContext viewContext, TextWriter writer)\r\n   在 System.Web.Mvc.ViewResultBase.ExecuteResult(ControllerContext context)\r\n   在 System.Web.Mvc.ControllerActionInvoker.InvokeActionResult(ControllerContext controllerContext, ActionResult actionResult)\r\n   在 System.Web.Mvc.ControllerActionInvoker.InvokeActionResultFilterRecursive(IList`1 filters, Int32 filterIndex, ResultExecutingContext preContext, ControllerContext controllerContext, ActionResult actionResult)\r\n   在 System.Web.Mvc.ControllerActionInvoker.InvokeActionResultFilterRecursive(IList`1 filters, Int32 filterIndex, ResultExecutingContext preContext, ControllerContext controllerContext, ActionResult actionResult)\r\n   在 System.Web.Mvc.ControllerActionInvoker.InvokeActionResultFilterRecursive(IList`1 filters, Int32 filterIndex, ResultExecutingContext preContext, ControllerContext controllerContext, ActionResult actionResult)\r\n   在 System.Web.Mvc.ControllerActionInvoker.InvokeActionResultWithFilters(ControllerContext controllerContext, IList`1 filters, ActionResult actionResult)\r\n   在 System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass21.<>c__DisplayClass2b.<BeginInvokeAction>b__1c()\r\n   在 System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass21.<BeginInvokeAction>b__1e(IAsyncResult asyncResult)', '10.10.133.209', '2017-08-29 14:53:32');
INSERT INTO `log_exception` VALUES ('12', '/Home/Index', '', 'd:\\github.GrainManage\\GrainManage.Web\\Views\\Home\\Index.cshtml(84): error CS0103: 当前上下文中不存在名称“UrlVar”\r\n', '   在 System.Web.Compilation.AssemblyBuilder.Compile()\r\n   在 System.Web.Compilation.BuildProvidersCompiler.PerformBuild()\r\n   在 System.Web.Compilation.BuildManager.CompileWebFile(VirtualPath virtualPath)\r\n   在 System.Web.Compilation.BuildManager.GetVPathBuildResultInternal(VirtualPath virtualPath, Boolean noBuild, Boolean allowCrossApp, Boolean allowBuildInPrecompile, Boolean throwIfNotFound, Boolean ensureIsUpToDate)\r\n   在 System.Web.Compilation.BuildManager.GetVPathBuildResultWithNoAssert(HttpContext context, VirtualPath virtualPath, Boolean noBuild, Boolean allowCrossApp, Boolean allowBuildInPrecompile, Boolean throwIfNotFound, Boolean ensureIsUpToDate)\r\n   在 System.Web.Compilation.BuildManager.GetVirtualPathObjectFactory(VirtualPath virtualPath, HttpContext context, Boolean allowCrossApp, Boolean throwIfNotFound)\r\n   在 System.Web.Compilation.BuildManager.GetCompiledType(VirtualPath virtualPath)\r\n   在 System.Web.Compilation.BuildManager.GetCompiledType(String virtualPath)\r\n   在 System.Web.Mvc.BuildManagerWrapper.System.Web.Mvc.IBuildManager.GetCompiledType(String virtualPath)\r\n   在 System.Web.Mvc.BuildManagerCompiledView.Render(ViewContext viewContext, TextWriter writer)\r\n   在 System.Web.Mvc.ViewResultBase.ExecuteResult(ControllerContext context)\r\n   在 System.Web.Mvc.ControllerActionInvoker.InvokeActionResult(ControllerContext controllerContext, ActionResult actionResult)\r\n   在 System.Web.Mvc.ControllerActionInvoker.InvokeActionResultFilterRecursive(IList`1 filters, Int32 filterIndex, ResultExecutingContext preContext, ControllerContext controllerContext, ActionResult actionResult)\r\n   在 System.Web.Mvc.ControllerActionInvoker.InvokeActionResultFilterRecursive(IList`1 filters, Int32 filterIndex, ResultExecutingContext preContext, ControllerContext controllerContext, ActionResult actionResult)\r\n   在 System.Web.Mvc.ControllerActionInvoker.InvokeActionResultFilterRecursive(IList`1 filters, Int32 filterIndex, ResultExecutingContext preContext, ControllerContext controllerContext, ActionResult actionResult)\r\n   在 System.Web.Mvc.ControllerActionInvoker.InvokeActionResultWithFilters(ControllerContext controllerContext, IList`1 filters, ActionResult actionResult)\r\n   在 System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass21.<>c__DisplayClass2b.<BeginInvokeAction>b__1c()\r\n   在 System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass21.<BeginInvokeAction>b__1e(IAsyncResult asyncResult)', '10.10.133.209', '2017-08-29 16:45:49');
INSERT INTO `log_exception` VALUES ('13', '/User/SignIn', '', '找不到方法:“System.String GrainManage.Web.UrlVar.get_User_ResetPassword()”。\r\n', '   在 ASP._Page_Views_User_SignIn_cshtml.Execute()\r\n   在 System.Web.WebPages.WebPageBase.ExecutePageHierarchy()\r\n   在 System.Web.Mvc.WebViewPage.ExecutePageHierarchy()\r\n   在 System.Web.WebPages.StartPage.RunPage()\r\n   在 System.Web.WebPages.StartPage.ExecutePageHierarchy()\r\n   在 System.Web.WebPages.WebPageBase.ExecutePageHierarchy(WebPageContext pageContext, TextWriter writer, WebPageRenderingBase startPage)\r\n   在 System.Web.Mvc.RazorView.RenderView(ViewContext viewContext, TextWriter writer, Object instance)\r\n   在 System.Web.Mvc.BuildManagerCompiledView.Render(ViewContext viewContext, TextWriter writer)\r\n   在 System.Web.Mvc.ViewResultBase.ExecuteResult(ControllerContext context)\r\n   在 System.Web.Mvc.ControllerActionInvoker.InvokeActionResult(ControllerContext controllerContext, ActionResult actionResult)\r\n   在 System.Web.Mvc.ControllerActionInvoker.InvokeActionResultFilterRecursive(IList`1 filters, Int32 filterIndex, ResultExecutingContext preContext, ControllerContext controllerContext, ActionResult actionResult)\r\n   在 System.Web.Mvc.ControllerActionInvoker.InvokeActionResultFilterRecursive(IList`1 filters, Int32 filterIndex, ResultExecutingContext preContext, ControllerContext controllerContext, ActionResult actionResult)\r\n   在 System.Web.Mvc.ControllerActionInvoker.InvokeActionResultFilterRecursive(IList`1 filters, Int32 filterIndex, ResultExecutingContext preContext, ControllerContext controllerContext, ActionResult actionResult)\r\n   在 System.Web.Mvc.ControllerActionInvoker.InvokeActionResultWithFilters(ControllerContext controllerContext, IList`1 filters, ActionResult actionResult)\r\n   在 System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass21.<>c__DisplayClass2b.<BeginInvokeAction>b__1c()\r\n   在 System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass21.<BeginInvokeAction>b__1e(IAsyncResult asyncResult)', '10.10.133.209', '2017-08-29 18:14:24');
INSERT INTO `log_exception` VALUES ('14', '/', '', '找不到方法:“System.String GrainManage.Web.UrlVar.get_User_ResetPassword()”。\r\n', '   在 ASP._Page_Views_User_SignIn_cshtml.Execute()\r\n   在 System.Web.WebPages.WebPageBase.ExecutePageHierarchy()\r\n   在 System.Web.Mvc.WebViewPage.ExecutePageHierarchy()\r\n   在 System.Web.WebPages.StartPage.RunPage()\r\n   在 System.Web.WebPages.StartPage.ExecutePageHierarchy()\r\n   在 System.Web.WebPages.WebPageBase.ExecutePageHierarchy(WebPageContext pageContext, TextWriter writer, WebPageRenderingBase startPage)\r\n   在 System.Web.Mvc.RazorView.RenderView(ViewContext viewContext, TextWriter writer, Object instance)\r\n   在 System.Web.Mvc.BuildManagerCompiledView.Render(ViewContext viewContext, TextWriter writer)\r\n   在 System.Web.Mvc.ViewResultBase.ExecuteResult(ControllerContext context)\r\n   在 System.Web.Mvc.ControllerActionInvoker.InvokeActionResult(ControllerContext controllerContext, ActionResult actionResult)\r\n   在 System.Web.Mvc.ControllerActionInvoker.InvokeActionResultFilterRecursive(IList`1 filters, Int32 filterIndex, ResultExecutingContext preContext, ControllerContext controllerContext, ActionResult actionResult)\r\n   在 System.Web.Mvc.ControllerActionInvoker.InvokeActionResultFilterRecursive(IList`1 filters, Int32 filterIndex, ResultExecutingContext preContext, ControllerContext controllerContext, ActionResult actionResult)\r\n   在 System.Web.Mvc.ControllerActionInvoker.InvokeActionResultFilterRecursive(IList`1 filters, Int32 filterIndex, ResultExecutingContext preContext, ControllerContext controllerContext, ActionResult actionResult)\r\n   在 System.Web.Mvc.ControllerActionInvoker.InvokeActionResultWithFilters(ControllerContext controllerContext, IList`1 filters, ActionResult actionResult)\r\n   在 System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass21.<>c__DisplayClass2b.<BeginInvokeAction>b__1c()\r\n   在 System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass21.<BeginInvokeAction>b__1e(IAsyncResult asyncResult)', '10.10.133.209', '2017-08-29 18:15:49');
INSERT INTO `log_exception` VALUES ('15', '/User/SignIn', '{\"UserName\":\"bijinshu\",\"Pwd\":\"40bd001563085fc35165329ea1ff5c5ecbdbbeef\"}', 'It was not possible to connect to the redis server(s); to create a disconnected multiplexer, disable AbortOnConnectFail. SocketFailure on PING\r\n', '   at StackExchange.Redis.ConnectionMultiplexer.ConnectImpl(Func`1 multiplexerFactory, TextWriter log) in c:\\code\\StackExchange.Redis\\StackExchange.Redis\\StackExchange\\Redis\\ConnectionMultiplexer.cs:line 890\r\n   at StackExchange.Redis.ConnectionMultiplexer.Connect(String configuration, TextWriter log) in c:\\code\\StackExchange.Redis\\StackExchange.Redis\\StackExchange\\Redis\\ConnectionMultiplexer.cs:line 855\r\n   at GrainManage.Web.Cache.RedisCache.get_Redis() in D:\\github.netcore.GrainManage\\GrainManage.Web\\Cache\\RedisCache.cs:line 126\r\n   at GrainManage.Web.Cache.RedisCache.GetDbClient(Int32 db) in D:\\github.netcore.GrainManage\\GrainManage.Web\\Cache\\RedisCache.cs:line 17\r\n   at GrainManage.Web.Cache.RedisCache.Set[T](String key, T value, Nullable`1 expiresAt) in D:\\github.netcore.GrainManage\\GrainManage.Web\\Cache\\RedisCache.cs:line 26\r\n   at GrainManage.Web.Controllers.UserController.SignIn(InputSignIn input) in D:\\github.netcore.GrainManage\\GrainManage.Web\\Controllers\\UserController.cs:line 69\r\n   at lambda_method(Closure , Object , Object[] )\r\n   at Microsoft.Extensions.Internal.ObjectMethodExecutor.Execute(Object target, Object[] parameters)\r\n   at Microsoft.AspNetCore.Mvc.Internal.ControllerActionInvoker.<InvokeActionMethodAsync>d__12.MoveNext()\r\n--- End of stack trace from previous location where exception was thrown ---\r\n   at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()\r\n   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)\r\n   at Microsoft.AspNetCore.Mvc.Internal.ControllerActionInvoker.<InvokeNextActionFilterAsync>d__10.MoveNext()\r\n--- End of stack trace from previous location where exception was thrown ---\r\n   at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()\r\n   at Microsoft.AspNetCore.Mvc.Internal.ControllerActionInvoker.Rethrow(ActionExecutedContext context)\r\n   at Microsoft.AspNetCore.Mvc.Internal.ControllerActionInvoker.Next(State& next, Scope& scope, Object& state, Boolean& isCompleted)\r\n   at Microsoft.AspNetCore.Mvc.Internal.ControllerActionInvoker.<InvokeInnerFilterAsync>d__14.MoveNext()\r\n--- End of stack trace from previous location where exception was thrown ---\r\n   at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()\r\n   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)\r\n   at Microsoft.AspNetCore.Mvc.Internal.ResourceInvoker.<InvokeNextExceptionFilterAsync>d__23.MoveNext()', '10.10.133.108', '2018-02-09 09:30:07');
INSERT INTO `log_exception` VALUES ('16', '/User/SignIn', '{\"UserName\":\"bijinshu\",\"Pwd\":\"40bd001563085fc35165329ea1ff5c5ecbdbbeef\"}', 'An exception occurred while reading a database value. The expected type was \'System.Int32\' but the actual value was of type \'System.Boolean\'.\r\nUnable to cast object of type \'System.Boolean\' to type \'System.Int32\'.\r\n', '   at Microsoft.EntityFrameworkCore.Metadata.Internal.EntityMaterializerSource.ThrowReadValueException[TValue](Exception exception, Object value, IPropertyBase property)\r\n   at lambda_method(Closure , DbDataReader )\r\n   at Microsoft.EntityFrameworkCore.Storage.Internal.TypedRelationalValueBufferFactory.Create(DbDataReader dataReader)\r\n   at Microsoft.EntityFrameworkCore.Query.Internal.QueryingEnumerable`1.Enumerator.BufferlessMoveNext(Boolean buffer)\r\n   at Microsoft.EntityFrameworkCore.Query.Internal.QueryingEnumerable`1.Enumerator.MoveNext()\r\n   at System.Linq.Enumerable.TryGetFirst[TSource](IEnumerable`1 source, Boolean& found)\r\n   at lambda_method(Closure , QueryContext )\r\n   at Microsoft.EntityFrameworkCore.Query.Internal.QueryCompiler.<>c__DisplayClass17_1`1.<CompileQueryCore>b__0(QueryContext qc)\r\n   at Microsoft.EntityFrameworkCore.Query.Internal.QueryCompiler.Execute[TResult](Expression query)\r\n   at Microsoft.EntityFrameworkCore.Query.Internal.EntityQueryProvider.Execute[TResult](Expression expression)\r\n   at System.Linq.Queryable.FirstOrDefault[TSource](IQueryable`1 source)\r\n   at GrainManage.Web.Controllers.UserController.SignIn(InputSignIn input) in D:\\github.netcore.GrainManage\\GrainManage.Web\\Controllers\\UserController.cs:line 42\r\n   at lambda_method(Closure , Object , Object[] )\r\n   at Microsoft.Extensions.Internal.ObjectMethodExecutor.Execute(Object target, Object[] parameters)\r\n   at Microsoft.AspNetCore.Mvc.Internal.ControllerActionInvoker.<InvokeActionMethodAsync>d__12.MoveNext()\r\n--- End of stack trace from previous location where exception was thrown ---\r\n   at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()\r\n   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)\r\n   at Microsoft.AspNetCore.Mvc.Internal.ControllerActionInvoker.<InvokeNextActionFilterAsync>d__10.MoveNext()\r\n--- End of stack trace from previous location where exception was thrown ---\r\n   at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()\r\n   at Microsoft.AspNetCore.Mvc.Internal.ControllerActionInvoker.Rethrow(ActionExecutedContext context)\r\n   at Microsoft.AspNetCore.Mvc.Internal.ControllerActionInvoker.Next(State& next, Scope& scope, Object& state, Boolean& isCompleted)\r\n   at Microsoft.AspNetCore.Mvc.Internal.ControllerActionInvoker.<InvokeInnerFilterAsync>d__14.MoveNext()\r\n--- End of stack trace from previous location where exception was thrown ---\r\n   at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()\r\n   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)\r\n   at Microsoft.AspNetCore.Mvc.Internal.ResourceInvoker.<InvokeNextExceptionFilterAsync>d__23.MoveNext()', '10.10.133.108', '2018-02-11 10:31:24');

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
) ENGINE=InnoDB AUTO_INCREMENT=80 DEFAULT CHARSET=utf8 COMMENT='后台登录日志';

-- ----------------------------
-- Records of log_login
-- ----------------------------
INSERT INTO `log_login` VALUES ('43', 'bijinshu', '10.10.133.108', '成功', '100', '0', '2017-12-28 14:20:49');
INSERT INTO `log_login` VALUES ('44', 'bijinshu', '10.10.133.108', '成功', '100', '0', '2017-12-28 14:25:00');
INSERT INTO `log_login` VALUES ('45', 'bijinshu', '10.10.133.108', '成功', '100', '0', '2017-12-28 14:27:02');
INSERT INTO `log_login` VALUES ('46', 'bijinshu', '10.10.133.108', '成功', '100', '0', '2017-12-28 14:27:18');
INSERT INTO `log_login` VALUES ('47', 'bijinshu', '10.10.133.108', '成功', '100', '0', '2017-12-28 14:45:36');
INSERT INTO `log_login` VALUES ('48', 'bijinshu', '10.10.133.108', '成功', '100', '0', '2017-12-28 14:56:20');
INSERT INTO `log_login` VALUES ('49', 'bijinshu', '10.10.133.108', '成功', '100', '0', '2017-12-28 18:19:42');
INSERT INTO `log_login` VALUES ('50', 'bijinshu', '10.10.133.108', '成功', '100', '0', '2017-12-28 19:04:25');
INSERT INTO `log_login` VALUES ('51', 'bijinshu', '127.0.0.1', '登录失败,用户名或密码错误.', '0', '0', '2017-12-29 13:08:12');
INSERT INTO `log_login` VALUES ('52', 'bijinshu', '127.0.0.1', '登录失败,用户名或密码错误.', '0', '0', '2017-12-29 13:08:19');
INSERT INTO `log_login` VALUES ('53', 'bijinshu', '127.0.0.1', '登录失败,用户名或密码错误.', '0', '0', '2017-12-29 13:08:32');
INSERT INTO `log_login` VALUES ('54', 'bijinshu', '127.0.0.1', '成功', '100', '0', '2017-12-29 13:08:38');
INSERT INTO `log_login` VALUES ('55', 'bijinshu', '10.10.133.108', '成功', '100', '0', '2018-01-02 09:40:31');
INSERT INTO `log_login` VALUES ('56', 'bijinshu', '10.10.133.108', '成功', '100', '0', '2018-01-02 17:35:17');
INSERT INTO `log_login` VALUES ('57', 'bijinshu', '10.10.133.108', '成功', '100', '0', '2018-01-03 09:25:22');
INSERT INTO `log_login` VALUES ('58', 'bijinshu', '10.10.133.108', '成功', '100', '0', '2018-01-03 11:47:26');
INSERT INTO `log_login` VALUES ('59', 'bijinshu', '10.10.133.108', '成功', '100', '0', '2018-01-03 14:15:21');
INSERT INTO `log_login` VALUES ('60', 'bijinshu', '127.0.0.1', '登录失败,用户名或密码错误.', '0', '0', '2018-01-03 16:01:03');
INSERT INTO `log_login` VALUES ('61', 'bijinshu', '127.0.0.1', '成功', '100', '0', '2018-01-03 16:01:08');
INSERT INTO `log_login` VALUES ('62', 'bijinshu', '127.0.0.1', '成功', '100', '0', '2018-01-04 15:01:18');
INSERT INTO `log_login` VALUES ('63', 'bijinshu', '127.0.0.1', '成功', '100', '0', '2018-01-04 15:01:36');
INSERT INTO `log_login` VALUES ('64', 'bijinshu', '127.0.0.1', '成功', '100', '0', '2018-01-04 20:09:09');
INSERT INTO `log_login` VALUES ('65', 'bijinshu', '192.168.86.128', '成功', '100', '0', '2018-01-04 20:44:57');
INSERT INTO `log_login` VALUES ('66', 'bijinshu', '192.168.86.1', '成功', '100', '0', '2018-01-04 21:07:51');
INSERT INTO `log_login` VALUES ('67', 'bijinshu', '192.168.86.1', '成功', '100', '0', '2018-01-04 21:09:34');
INSERT INTO `log_login` VALUES ('68', 'bijinshu', '192.168.86.1', '成功', '100', '0', '2018-01-06 19:39:24');
INSERT INTO `log_login` VALUES ('69', 'bijinshu', '10.10.133.108', '成功', '100', '0', '2018-02-09 09:32:36');
INSERT INTO `log_login` VALUES ('70', 'bijinshu', '10.10.133.108', '成功', '100', '0', '2018-02-09 10:47:23');
INSERT INTO `log_login` VALUES ('71', 'bijinshu', '10.10.133.108', '成功', '100', '0', '2018-02-09 10:49:54');
INSERT INTO `log_login` VALUES ('72', 'bijinshu', '10.10.133.108', '成功', '100', '0', '2018-02-11 10:31:29');
INSERT INTO `log_login` VALUES ('73', 'bijinshu', '10.10.133.108', '成功', '100', '0', '2018-02-11 18:23:54');
INSERT INTO `log_login` VALUES ('74', 'bijinshu', '10.10.133.108', '成功', '100', '0', '2018-02-12 15:58:26');
INSERT INTO `log_login` VALUES ('75', 'bijinshu', '10.10.133.108', '成功', '100', '0', '2018-02-12 17:40:46');
INSERT INTO `log_login` VALUES ('76', 'bijinshu', '10.10.133.108', '成功', '100', '0', '2018-02-12 17:42:59');
INSERT INTO `log_login` VALUES ('77', 'bijinshu', '10.10.133.108', '成功', '100', '0', '2018-02-12 17:43:35');
INSERT INTO `log_login` VALUES ('78', 'bijinshu', '10.10.133.108', '成功', '100', '0', '2018-02-13 10:56:40');
INSERT INTO `log_login` VALUES ('79', 'bijinshu', '10.10.133.108', '成功', '100', '0', '2018-02-13 14:22:05');

-- ----------------------------
-- Table structure for `rm_address`
-- ----------------------------
DROP TABLE IF EXISTS `rm_address`;
CREATE TABLE `rm_address` (
  `Url` varchar(255) NOT NULL DEFAULT '' COMMENT '地址',
  `IsWatching` tinyint(6) NOT NULL COMMENT '0:不监控 1:监控 ',
  `IsValid` tinyint(6) NOT NULL COMMENT '0:无效地址 1:有效地址',
  `TypeId` smallint(6) NOT NULL COMMENT '0:一般地址 1:公共地址（免权限验证）',
  `Remark` varchar(200) NOT NULL DEFAULT '' COMMENT '说明',
  `CreatedAt` datetime NOT NULL COMMENT '创建时间',
  `ModifiedAt` datetime DEFAULT NULL COMMENT '修改时间',
  PRIMARY KEY (`Url`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='地址监控配置表';

-- ----------------------------
-- Records of rm_address
-- ----------------------------
INSERT INTO `rm_address` VALUES ('/Contact/Delete', '1', '1', '0', '', '2018-02-11 16:43:27', null);
INSERT INTO `rm_address` VALUES ('/Contact/Edit', '1', '1', '0', '', '2018-02-11 16:43:27', null);
INSERT INTO `rm_address` VALUES ('/Contact/Index', '0', '1', '0', '', '2018-02-11 16:43:27', null);
INSERT INTO `rm_address` VALUES ('/Contact/New', '1', '1', '0', '', '2018-02-11 16:43:27', null);
INSERT INTO `rm_address` VALUES ('/Home/Index', '0', '1', '1', '', '2018-02-11 16:43:23', null);
INSERT INTO `rm_address` VALUES ('/Role/Delete', '1', '1', '0', '', '2018-02-11 16:43:27', null);
INSERT INTO `rm_address` VALUES ('/Role/Edit', '1', '1', '0', '', '2018-02-11 16:43:27', null);
INSERT INTO `rm_address` VALUES ('/Role/Index', '0', '1', '0', '', '2018-02-11 16:43:27', null);
INSERT INTO `rm_address` VALUES ('/Role/New', '1', '1', '0', '', '2018-02-11 16:43:27', null);
INSERT INTO `rm_address` VALUES ('/User/ChangePwd', '1', '1', '1', '', '2018-02-11 16:43:27', null);
INSERT INTO `rm_address` VALUES ('/User/Delete', '1', '1', '0', '', '2018-02-11 16:43:27', null);
INSERT INTO `rm_address` VALUES ('/User/Edit', '1', '1', '0', '', '2018-02-11 16:43:27', null);
INSERT INTO `rm_address` VALUES ('/User/Index', '0', '1', '0', '', '2018-02-11 16:43:27', null);
INSERT INTO `rm_address` VALUES ('/User/Info', '0', '1', '1', '', '2018-02-11 16:43:27', null);
INSERT INTO `rm_address` VALUES ('/User/New', '1', '1', '0', '', '2018-02-11 16:43:27', null);
INSERT INTO `rm_address` VALUES ('/User/Register', '1', '1', '0', '', '2018-02-11 16:43:27', null);
INSERT INTO `rm_address` VALUES ('/User/ResetPwd', '1', '1', '0', '', '2018-02-11 16:43:27', null);
INSERT INTO `rm_address` VALUES ('/User/SignIn', '0', '1', '0', '', '2018-02-11 16:43:27', null);
INSERT INTO `rm_address` VALUES ('/User/SignOut', '1', '1', '1', '', '2018-02-11 16:43:27', null);

-- ----------------------------
-- Table structure for `rm_role`
-- ----------------------------
DROP TABLE IF EXISTS `rm_role`;
CREATE TABLE `rm_role` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(20) NOT NULL COMMENT '角色名称',
  `Auths` varchar(600) NOT NULL DEFAULT '' COMMENT '权限列表',
  `Level` smallint(6) NOT NULL COMMENT '级别',
  `Remark` varchar(600) NOT NULL DEFAULT '' COMMENT '备注',
  `CreatedAt` datetime NOT NULL COMMENT '创建时间',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8 COMMENT='系统角色，每个子系统都应该建立一个对应角色';

-- ----------------------------
-- Records of rm_role
-- ----------------------------
INSERT INTO `rm_role` VALUES ('1', '超级管理员', '', '100', '', '2016-03-05 18:09:24');
INSERT INTO `rm_role` VALUES ('2', '普通用户', '', '0', '普通注册用户或关注公众号的用户', '2016-03-05 18:09:47');
INSERT INTO `rm_role` VALUES ('3', '商户', '', '0', '粮食收购商户', '2017-07-19 18:27:34');
INSERT INTO `rm_role` VALUES ('4', '系统管理员', 'price,contact,customer,purchase,sale,retail,system,system.role,system.role.view,system.role.add,system.role.edit,system.role.delete,system.user,system.user.view,system.user.add,system.user.edit,system.user.delete,system.user.append,user,user.change_pwd,user.sign_out', '30', '管理系统用户', '2017-08-29 15:07:11');

-- ----------------------------
-- Table structure for `rm_user`
-- ----------------------------
DROP TABLE IF EXISTS `rm_user`;
CREATE TABLE `rm_user` (
  `Id` int(32) NOT NULL AUTO_INCREMENT COMMENT '全局唯一编号',
  `UserName` varchar(20) NOT NULL DEFAULT '' COMMENT '用户名称、登录名称',
  `AppId` int(11) NOT NULL COMMENT '应用编号',
  `Pwd` varchar(42) NOT NULL DEFAULT '' COMMENT '密码',
  `Gender` smallint(6) NOT NULL DEFAULT '0' COMMENT '0:男 1:女',
  `Status` smallint(6) NOT NULL DEFAULT '0' COMMENT '0:禁用 1:启用',
  `RealName` varchar(20) NOT NULL DEFAULT '' COMMENT '真实姓名',
  `Mobile` char(11) NOT NULL DEFAULT '' COMMENT '手机号码',
  `Email` varchar(64) NOT NULL DEFAULT '' COMMENT '邮箱',
  `QQ` varchar(20) NOT NULL DEFAULT '' COMMENT 'QQ',
  `Weixin` varchar(20) NOT NULL DEFAULT '' COMMENT '微信',
  `Roles` varchar(200) NOT NULL DEFAULT '' COMMENT '角色',
  `Remark` varchar(200) NOT NULL DEFAULT '' COMMENT '备注',
  `CreatedAt` datetime NOT NULL COMMENT '创建时间',
  `CreatedBy` int(11) NOT NULL COMMENT '创建者： -1:系统注册 >0 表内其它用户',
  `ModifiedAt` datetime DEFAULT NULL COMMENT '上次活动时间',
  PRIMARY KEY (`Id`),
  KEY `uq_user_name` (`UserName`),
  KEY `index_mobile` (`Mobile`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8 COMMENT='用户表';

-- ----------------------------
-- Records of rm_user
-- ----------------------------
INSERT INTO `rm_user` VALUES ('1', 'bijinshu', '1', '9adcb29710e807607b683f62e555c22dc5659713', '0', '1', '毕金书', '15801992799', '914023961@qq.com', '914023961', 'bijinshu', '1', 'bijinshu', '2016-01-05 18:44:49', '0', '2018-02-12 17:01:43');
INSERT INTO `rm_user` VALUES ('2', 'testadmin', '0', '9adcb29710e807607b683f62e555c22dc5659713', '0', '1', '管理员', '15801992799', 'bijinshu@163.com', '12863589', 'bijinshu', '3', '555', '2016-01-05 18:44:49', '1', '2018-02-11 11:50:22');
INSERT INTO `rm_user` VALUES ('3', 'testroot', '0', '9adcb29710e807607b683f62e555c22dc5659713', '1', '1', '管理员', '15801992799', 'bijinshu@163.com', '96584258', '', '2', 'testroot', '2016-01-05 18:44:49', '1', '2018-02-11 10:33:42');
INSERT INTO `rm_user` VALUES ('4', 'ssss', '4', 'df392b4831917b9b409e7b76790280d96095611c', '0', '0', '当对方', '15648762587', '', '', '', '', '', '2018-02-12 18:07:02', '0', null);

-- ----------------------------
-- Table structure for `rm_white_ip`
-- ----------------------------
DROP TABLE IF EXISTS `rm_white_ip`;
CREATE TABLE `rm_white_ip` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `IP` varchar(16) NOT NULL DEFAULT '' COMMENT 'IP',
  `CreatedAt` datetime NOT NULL COMMENT '创建时间',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8 COMMENT='ip白名单';

-- ----------------------------
-- Records of rm_white_ip
-- ----------------------------
INSERT INTO `rm_white_ip` VALUES ('1', '10.10.133.108', '2018-02-11 16:42:31');