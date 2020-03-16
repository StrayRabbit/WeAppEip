/*
 Navicat Premium Data Transfer

 Source Server         : Eip
 Source Server Type    : MySQL
 Source Server Version : 80017
 Source Host           : localhost:3306
 Source Schema         : eip

 Target Server Type    : MySQL
 Target Server Version : 80017
 File Encoding         : 65001

 Date: 16/03/2020 22:42:42
*/

SET NAMES utf8mb4;
SET FOREIGN_KEY_CHECKS = 0;

-- ----------------------------
-- Table structure for banners
-- ----------------------------
DROP TABLE IF EXISTS `banners`;
CREATE TABLE `banners`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `description` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin NULL DEFAULT NULL,
  `image_url` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin NULL DEFAULT NULL,
  `href` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin NULL DEFAULT NULL,
  `order` int(255) NULL DEFAULT NULL,
  `createuserid` int(11) NULL DEFAULT NULL,
  `createdate` datetime(0) NULL DEFAULT NULL,
  `updateuserid` int(11) NULL DEFAULT NULL,
  `updatedate` datetime(0) NULL DEFAULT NULL,
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 19 CHARACTER SET = utf8 COLLATE = utf8_bin ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of banners
-- ----------------------------
INSERT INTO `banners` VALUES (17, NULL, '/upload/banner/9c85458807254aa7a474f770fc2a2820.jpg', NULL, 0, 1, '2020-03-15 16:49:38', 1, '2020-03-16 22:19:51');
INSERT INTO `banners` VALUES (18, '小巷', '/upload/banner/2a5ff5eabf7d44d3bd0a06569fee2e3c.jpg', NULL, 0, 1, '2020-03-15 16:55:57', 1, '2020-03-16 22:21:02');

-- ----------------------------
-- Table structure for customers
-- ----------------------------
DROP TABLE IF EXISTS `customers`;
CREATE TABLE `customers`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `openid` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin NOT NULL,
  `nickName` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin NULL DEFAULT NULL,
  `avatarUrl` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin NULL DEFAULT NULL,
  `gender` int(255) NULL DEFAULT NULL,
  `country` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin NULL DEFAULT NULL,
  `province` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin NULL DEFAULT NULL,
  `city` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin NULL DEFAULT NULL,
  `lastLoginTime` datetime(0) NULL DEFAULT NULL,
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 2 CHARACTER SET = utf8 COLLATE = utf8_bin ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of customers
-- ----------------------------
INSERT INTO `customers` VALUES (1, 'olc5_4heb15cMCq3Qz75byPHQx4k', '王辉', 'https://wx.qlogo.cn/mmopen/vi_32/Q0j4TwGTfTIzlzquFt9FibftJyfcDhKGfTUmuduJlj04Ff9xRR2H050WemE3UjcgrUXavP44iax6PR6oiaLxNt73A/132', 1, 'China', 'Hebei', 'Shijiazhuang', '2020-03-16 22:24:02');

-- ----------------------------
-- Table structure for news
-- ----------------------------
DROP TABLE IF EXISTS `news`;
CREATE TABLE `news`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `type` int(255) NULL DEFAULT NULL,
  `title` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin NULL DEFAULT NULL,
  `image_url` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin NULL DEFAULT NULL,
  `introduction` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin NULL DEFAULT NULL,
  `content` text CHARACTER SET utf8 COLLATE utf8_bin NULL,
  `order` int(255) NULL DEFAULT NULL,
  `createuserid` int(11) NULL DEFAULT NULL,
  `createdate` datetime(0) NULL DEFAULT NULL,
  `updateuserid` int(11) NULL DEFAULT NULL,
  `updatedate` datetime(0) NULL DEFAULT NULL,
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 12 CHARACTER SET = utf8 COLLATE = utf8_bin ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of news
-- ----------------------------
INSERT INTO `news` VALUES (10, 1, '2019年度中央国家机关会计人员继续教育报名须知', '/upload/news/5d21a4d85e134ff2b494b9c261749999.jpg', '石油化工管理干部学院隶属于中国石油化工集团公司，是集集团公司党校、人才培训中心、继续工程教育中心、信息技术培训中心、远程教育中心、会计继续教育培训六位一体的高级人才培训基地', '&lt;p&gt;&lt;a href=\"http://www.bianchengcn.com//upload/richtext/81fb3c164bf3407d81ed2cb28355a2a9.doc\"&gt;2019报名表.doc&lt;/a&gt;&lt;/p&gt;\n\n&lt;p&gt;尊敬的各位学员：&lt;/p&gt;\n\n&lt;p&gt;您好！欢迎您来到石油化工管理干部学院，参加中央国家机关会计人员（初、中级）继续教育培训。根据《&lt;strong&gt;关于&lt;/strong&gt;&lt;strong&gt;2019&lt;/strong&gt;&lt;strong&gt;年度中央国家机关会计专业技术人员继续教育有关事项的通知&lt;/strong&gt;》,结合本单位工作实际，现将报名、培训等有关事宜进行说明。&lt;/p&gt;\n\n&lt;p&gt;&amp;nbsp;&lt;/p&gt;\n\n&lt;p&gt;&lt;strong&gt;一、&lt;/strong&gt;&lt;strong&gt;&amp;nbsp;&amp;nbsp;&amp;nbsp;&amp;nbsp;&lt;/strong&gt;&lt;strong&gt;学院简介&lt;/strong&gt;&lt;/p&gt;\n\n&lt;p&gt;石油化工管理干部学院隶属于中国石油化工集团公司，是集集团公司党校、人才培训中心、继续工程教育中心、信息技术培训中心、远程教育中心、会计继续教育培训六位一体的高级人才培训基地。总部在立水桥，分部在健翔桥（安翔桥）。&lt;/p&gt;\n\n&lt;p&gt;&lt;strong&gt;学院网址&lt;/strong&gt;：http://smi.sinopec.com/smi/&lt;/p&gt;\n\n&lt;p&gt;&lt;strong&gt;分部健翔桥校区&lt;/strong&gt;：位于朝阳区北四环健翔桥北安翔北里11号院（306医院南面）。乘坐公交407、695、751、625、特13、618、345、到&lt;strong&gt;安翔桥北（南）站&lt;/strong&gt;下车即可。&lt;/p&gt;\n\n&lt;p&gt;地铁：&lt;strong&gt;10&lt;/strong&gt;号线&lt;strong&gt;健德门&lt;/strong&gt;站下车，换成公交车到&lt;strong&gt;安翔桥北&lt;/strong&gt;下车即可。&lt;/p&gt;\n\n&lt;p&gt;&amp;nbsp;&lt;/p&gt;\n\n&lt;p&gt;&lt;strong&gt;二、&lt;/strong&gt;&lt;strong&gt;&amp;nbsp;&amp;nbsp;&amp;nbsp;&amp;nbsp;&lt;/strong&gt;&lt;strong&gt;培训安排&lt;/strong&gt;：&lt;/p&gt;\n\n&lt;table cellpadding=\"0\" cellspacing=\"0\" style=\"width:552px\"&gt;\n	&lt;tbody&gt;\n		&lt;tr&gt;\n			&lt;td rowspan=\"2\"&gt;\n			&lt;p&gt;&lt;strong&gt;期次&lt;/strong&gt;&lt;/p&gt;\n			&lt;/td&gt;\n			&lt;td rowspan=\"2\"&gt;\n			&lt;p&gt;&lt;strong&gt;培 训 时 间&lt;/strong&gt;&lt;/p&gt;\n			&lt;/td&gt;\n			&lt;td&gt;\n			&lt;p&gt;&lt;strong&gt;培 训 地 点&lt;/strong&gt;&lt;/p&gt;\n			&lt;/td&gt;\n			&lt;td&gt;&amp;nbsp;&lt;/td&gt;\n		&lt;/tr&gt;\n		&lt;tr&gt;\n			&lt;td&gt;&amp;nbsp;&lt;/td&gt;\n			&lt;td&gt;&amp;nbsp;&lt;/td&gt;\n		&lt;/tr&gt;\n		&lt;tr&gt;\n			&lt;td rowspan=\"3\"&gt;\n			&lt;p&gt;1&lt;/p&gt;\n			&lt;/td&gt;\n			&lt;td rowspan=\"3\"&gt;\n			&lt;p&gt;2019.9.16-9.20&lt;/p&gt;\n			&lt;/td&gt;\n			&lt;td rowspan=\"3\"&gt;\n			&lt;p&gt;石油化工管理干部学院健翔桥校区&lt;/p&gt;\n			&lt;/td&gt;\n			&lt;td&gt;&amp;nbsp;&lt;/td&gt;\n		&lt;/tr&gt;\n		&lt;tr&gt;\n			&lt;td&gt;&amp;nbsp;&lt;/td&gt;\n		&lt;/tr&gt;\n		&lt;tr&gt;\n			&lt;td&gt;&amp;nbsp;&lt;/td&gt;\n		&lt;/tr&gt;\n		&lt;tr&gt;\n			&lt;td rowspan=\"3\"&gt;\n			&lt;p&gt;2&lt;/p&gt;\n			&lt;/td&gt;\n			&lt;td rowspan=\"3\"&gt;\n			&lt;p&gt;2019.10.14-10.18&lt;/p&gt;\n			&lt;/td&gt;\n			&lt;td rowspan=\"3\"&gt;\n			&lt;p&gt;石油化工管理干部学院健翔桥校区&lt;/p&gt;\n			&lt;/td&gt;\n			&lt;td&gt;&amp;nbsp;&lt;/td&gt;\n		&lt;/tr&gt;\n		&lt;tr&gt;\n			&lt;td&gt;&amp;nbsp;&lt;/td&gt;\n		&lt;/tr&gt;\n		&lt;tr&gt;\n			&lt;td&gt;&amp;nbsp;&lt;/td&gt;\n		&lt;/tr&gt;\n		&lt;tr&gt;\n			&lt;td rowspan=\"3\"&gt;\n			&lt;p&gt;3&lt;/p&gt;\n			&lt;/td&gt;\n			&lt;td rowspan=\"3\"&gt;\n			&lt;p&gt;2019.11.4-11.8&lt;/p&gt;\n			&lt;/td&gt;\n			&lt;td rowspan=\"3\"&gt;\n			&lt;p&gt;石油化工管理干部学院健翔桥校区&lt;/p&gt;\n			&lt;/td&gt;\n			&lt;td&gt;&amp;nbsp;&lt;/td&gt;\n		&lt;/tr&gt;\n		&lt;tr&gt;\n			&lt;td&gt;&amp;nbsp;&lt;/td&gt;\n		&lt;/tr&gt;\n		&lt;tr&gt;\n			&lt;td&gt;&amp;nbsp;&lt;/td&gt;\n		&lt;/tr&gt;\n	&lt;/tbody&gt;\n&lt;/table&gt;\n\n&lt;p&gt;培训内容：《&lt;strong&gt;社保与环保新规》解读、增值税风险与防控、中美贸易摩擦及其影响,职工健康管理、压力管理&lt;/strong&gt;。&lt;/p&gt;\n\n&lt;p&gt;&amp;nbsp;&lt;/p&gt;\n\n&lt;p&gt;&lt;strong&gt;三、报名方式：（注意：参加会计继教的学员一定要按照国管局的规定完成信息采集，否则培训结果无法登记。）&lt;/strong&gt;&lt;/p&gt;\n\n&lt;p&gt;&amp;nbsp;&amp;nbsp;&amp;nbsp;&amp;nbsp;登陆&lt;strong&gt;国管局会计网&lt;/strong&gt;&lt;a href=\"http://www.ggj.gov.cn/kjw/\"&gt;http://www.ggj.gov.cn/kjw/&lt;/a&gt;，详见通知公告中《&lt;strong&gt;关于2019年度中央国家机关会计专业技术人员继续教育有关事项的通知&lt;/strong&gt;》，明确报名对象及培训要求。在本文附件中下载《2019年中央国家机关会计人员继续教育培训报名表》，请将个人信息准确无误填到报名表，一定要备注培训期次和手机联系方式（便于及时联系），并发送至电子邮箱：&lt;strong&gt;&lt;a href=\"mailto:muh.glgy@sinopec.com\"&gt;muh.glgy@sinopec.com&lt;/a&gt;&lt;/strong&gt;进行报名。报名电话：52591527&lt;/p&gt;\n\n&lt;p&gt;&lt;strong&gt;四、&lt;/strong&gt;&lt;strong&gt;&amp;nbsp;&amp;nbsp;&amp;nbsp;&lt;/strong&gt;&lt;strong&gt;收费标准&lt;/strong&gt;：&lt;/p&gt;\n\n&lt;p&gt;按照《中央国家机关培训费管理办法》（财行〔2016〕540号）标准执行。规定：中初级会计人员继续教育培训收费标准为面授培训210元/人/天（不含住宿）、80元/人/天（不含食宿）。&lt;/p&gt;\n\n&lt;p&gt;&lt;strong&gt;培训费：1050/元人（含餐无住宿）；400/人（无餐无住宿）&lt;/strong&gt;&lt;/p&gt;\n\n&lt;p&gt;&amp;nbsp;&lt;/p&gt;\n\n&lt;p&gt;&lt;strong&gt;五、&lt;/strong&gt;&lt;strong&gt;&amp;nbsp;&amp;nbsp;&amp;nbsp;&amp;nbsp;&lt;/strong&gt;&lt;strong&gt;收费时间&lt;/strong&gt;、&lt;strong&gt;地点及方式&lt;/strong&gt;：（交费前需要再确认）&lt;/p&gt;\n\n&lt;p&gt;学员须在交费前填写《2019年中央国家机关会计人员继续教育培训报名表》，并发送到指定邮箱：muh.glgy@sinopec.com，交费前请打电话再次确认个人信息，方可到我培训中心一楼前台交费。增值税一般纳税人如需开具增值税专用发票，请在交费时提交《增值税专用发票开票信息采集表》。&lt;strong&gt;注：由于学员个人原因交费后不能参加培训的，或者出勤率不达标者，一概不退费且培训不予通过&lt;/strong&gt;。&lt;/p&gt;\n\n&lt;p&gt;健翔桥校区：周三上午：9.4、9.11、9.25、10.9、10.23、10.30；开班当天：9.16、10.14、11.4 上午8：30前；请到北楼一层前台交费并登记，领听课证、餐票。&lt;/p&gt;\n\n&lt;p&gt;其他时间交费请到立水桥校区综合楼总服务台收费处。&lt;/p&gt;\n\n&lt;p&gt;系统内单位汇款需通过集中核算交易平台进行结算或者刷卡。&lt;/p&gt;\n\n&lt;p&gt;系统外单位通过刷卡（银联卡）、现金、汇款方式进行结算。&lt;/p&gt;\n\n&lt;p&gt;单位账号：0200095829000056468，开户行：工商银行北京天通苑支行，账户名称：石油化工管理干部学院，请注明：会计继教培训费及汇款单位名称。&lt;/p&gt;\n\n&lt;p&gt;&amp;nbsp;&lt;/p&gt;\n\n&lt;p&gt;&lt;strong&gt;六、上课时间&lt;/strong&gt;：上午8：30--12：00&amp;nbsp;&amp;nbsp; 下午1：00--3：00&lt;/p&gt;\n\n&lt;p&gt;&lt;strong&gt;上课地点&lt;/strong&gt;：健翔桥校区石化南楼四层报告厅。&lt;/p&gt;\n\n&lt;p&gt;&amp;nbsp;&lt;/p&gt;\n\n&lt;p&gt;&lt;strong&gt;七、就餐时间&lt;/strong&gt;：12：00&amp;nbsp;&lt;strong&gt;就餐地点&lt;/strong&gt;：健翔桥校区南楼二层餐厅。&lt;/p&gt;\n\n&lt;p&gt;&amp;nbsp;&lt;/p&gt;\n\n&lt;p&gt;&lt;strong&gt;八、&lt;/strong&gt;&lt;strong&gt;考勤管理：&lt;/strong&gt;&lt;/p&gt;\n\n&lt;p&gt;为了进一步加强上课纪律及考勤管理，确保学员完成培训任务。规定：每天上下午，课前签到，上下午课中两次考勤；缺勤及请假超过&lt;strong&gt;半天&lt;/strong&gt;的学员，当期培训无效，只能重新申请参加其它期次的培训。请学员自学遵守，积极配合。&amp;nbsp;&lt;/p&gt;\n\n&lt;p&gt;&lt;strong&gt;&amp;nbsp;&amp;nbsp;&amp;nbsp; 九、注意安全，防火，防盗，如遇突发事件，必须听从班主任和老师指挥，安全有序的撤离现场&lt;/strong&gt;。&lt;/p&gt;\n\n&lt;p&gt;&amp;nbsp;&lt;/p&gt;', NULL, 1, '2019-09-22 08:47:37', 1, '2020-03-16 22:10:41');
INSERT INTO `news` VALUES (11, 2, '“三强”年轻干部能力强化班召开“不忘初心、牢记使命”主题教育专题组织生活会', '/upload/news/76f2ee4e6bf246f8a962be291fd83cf7.jpg', '“三强”年轻干部能力强化班召开“不忘初心、牢记使命”主题教育专题组织生活会', '&lt;p&gt;&amp;nbsp;&amp;nbsp;&amp;nbsp;&amp;nbsp;12月4日，按照集团公司人事部和学院有关要求，中国石化&amp;ldquo;三强&amp;rdquo;年轻干部能力强化班临时党支部组织各党小组召开&amp;ldquo;不忘初心、牢记使命&amp;rdquo;专题组织生活会，各位党员紧扣学习贯彻习近平新时代中国特色社会主义思想，围绕主题教育的五个具体目标，按照&amp;ldquo;四个对照&amp;rdquo;、&amp;ldquo;四个找一找&amp;rdquo;的要求，紧密联系工作实际和这次培训学习，盘点收获、检视问题、深刻剖析，明确整改措施，认真开展批评与自我批评。&lt;/p&gt;\n\n&lt;p&gt;&amp;nbsp;&amp;nbsp;&amp;nbsp; 培训班指导老师和临时党支部对这次专题组织生活会高度重视，把开好专题组织生活会作为守初心、担使命，找差距、抓落实的一次政治体检，作为检视主题教育成效和这次学习培训效果的一项重要内容，从会议主题、基本要求、方法步骤、组织领导等方面，对召开组织生活会和开展民主评议党员进行了全面部署，并专门邀请中央党校、管理干部学院多位教授进行党性分析专题辅导，组织各小组深入开展谈心谈话，全面梳理检视问题，认真撰写检视剖析材料，为开好组织生活会打下坚实基础。&lt;/p&gt;\n\n&lt;p&gt;&amp;nbsp;&amp;nbsp;&amp;nbsp; 各小组党员同志逐一发言，大家直奔主题、开门见山，将检视问题贯穿会议全过程，既找理论短板、工作弱项，又找思想差距、作风不足，不仅把问题讲清楚，而且把问题根源讲透彻，把整改措施讲具体，体现了强烈的自我革命精神，达到了红脸出汗、触动思想、增进团结、促进工作的效果。&lt;/p&gt;\n\n&lt;p&gt;&amp;nbsp;&amp;nbsp;&amp;nbsp; 全体党员一致认为，通过专题组织生活会和民主评议党员，大家经历了一次严格的党内政治生活锻炼和党性锻炼，受到了一次理想信念和党的优良传统的深刻教育，进一步提高了自觉加强党性修养的意识，也进一步找准了自身存在的突出问题，查明了存在问题的原因，明确了今后努力的方向。&lt;/p&gt;\n\n&lt;p&gt;&amp;nbsp;&amp;nbsp;&amp;nbsp; 一要加强政治建设，坚决做到&amp;ldquo;两个维护&amp;rdquo;。要持续深入学习贯彻习近平新时代中国特色社会主义思想，进一步增强&amp;ldquo;四个意识&amp;rdquo;、坚定&amp;ldquo;四个自信&amp;rdquo;、做到&amp;ldquo;两个维护&amp;rdquo;，始终在政治立场、政治方向、政治原则、政治道路上同以习近平同志为核心的党中央保持高度一致。&lt;/p&gt;\n\n&lt;p&gt;&amp;nbsp;&amp;nbsp;&amp;nbsp; 二要坚持问题导向，抓好整改落实。针对本次专题组织生活会上检视出的问题，列出问题清单，完善整改措施，明确完成时限，做到即知即改、立行立改、全面整改、彻底整改，确保整改落实取得实效。&lt;/p&gt;\n\n&lt;p&gt;&amp;nbsp;&amp;nbsp;&amp;nbsp; 三要强化责任担当，统筹推进工作。更加自觉地贯彻落实中央精神和集团公司党组决策部署，用好这次主题教育成果和&amp;ldquo;三强&amp;rdquo;班学习成果，把学习收获转化为思路举措和工作实绩，不忘初心、牢记使命，坚持奉献奋进，敢于担当负责，为集团公司加快推进&amp;ldquo;两个三年、两个十年&amp;rdquo;打造世界一流战略部署贡献力量。（刘新华田婧然 姚进 赵科 王佳）&lt;/p&gt;', NULL, 1, '2019-12-14 15:18:32', 1, '2020-03-16 22:15:57');
INSERT INTO `news` VALUES (12, 1, '学院党委中心组召开疫情防控和复工复产学习研讨会议', '/upload/news/bf52973a501a47e3b05716467dd925d8.jpg', '学院党委中心组召开疫情防控和复工复产学习研讨会议', '&lt;p&gt;&amp;nbsp;&amp;nbsp;&amp;nbsp;&amp;nbsp;&amp;nbsp;&amp;nbsp;&amp;nbsp;&amp;nbsp;2月28日，学院召开党委中心组（扩大）学习会议，学院党委书记李德芳、院长王子康，党委副书记、纪委书记、工会主席李寿军，副院长罗锡庆、副院长郭英杰，以及院长办公室、人事处、行政管理处、教务处、后勤服务中心主要负责人参加。&lt;/p&gt;\n\n&lt;p&gt;&amp;nbsp;&amp;nbsp;&amp;nbsp;&amp;nbsp;&amp;nbsp;&amp;nbsp;&amp;nbsp;&amp;nbsp;会上，李德芳领学《习近平总书记在统筹推进新冠肺炎疫情防控和经济社会发展工作部署会议上的讲话》。&lt;/p&gt;\n\n&lt;p&gt;&amp;nbsp;&amp;nbsp;&amp;nbsp;&amp;nbsp;&amp;nbsp;&amp;nbsp;&amp;nbsp;&amp;nbsp;党委书记李德芳就进一步做好学院疫情防控和复工复产工作，做出了安排部署，要求各相关部门切实担负责任，抓好贯彻落实。一是按照《关于进一步加强学院疫情防控工作的通知》（石化干院疫防办〔2020〕5号）相关要求，持续从严从紧做好疫情防控工作。要做好到院上班人员健康状况把关、学院重点场所防控管理、防护物资采购供应等工作。继续严控服务外包公司在岗人员管理。严格审查、从严管理外地返京人员，仔细摸排学院教职员工、外包公司员工健康状况。严格控制到院人数，近期各部门到院上岗人数不超20%。进一步完善学院各方面疫情防控应急预案，各部门密切关注疫情发展态势，保持高度警惕。二是加大举办各类网络培训班力度，积极推进各项科研工作。三是抓紧完善中国石化网络学院升级方案，为下一步网络学院高质量发展打好基础。四是按照年度目标任务和重点工作安排，有序推进党建、纪检、工会、宣传、群团等工作。五是密切与发展计划部联络沟通，切实加快推进学院综合楼改造工程相关工作。&lt;/p&gt;\n\n&lt;p&gt;&lt;img src=\"http://smi.sinopec.com/smi/news/col_news/PublishingImages/20200302/img_20200302_408215130166.jpg\" title=\"20200302105941433.jpg\" /&gt;&lt;/p&gt;\n\n&lt;p&gt;&amp;nbsp;&lt;/p&gt;', NULL, 1, '2020-03-16 22:12:52', NULL, NULL);
INSERT INTO `news` VALUES (13, 1, '学院认真学习贯彻集团公司疫情防控和复工复产视频会议精神', '/upload/news/07a2ea84ed79443d88f1e16815de29af.jpg', '学院认真学习贯彻集团公司疫情防控和复工复产视频会议精神', '&lt;p&gt;&amp;nbsp; &amp;nbsp; &amp;nbsp; &amp;nbsp;2月26日下午，学院组织收看集团公司疫情防控和复工复产视频会议。院领导班子成员、各部门主要负责人参加会议，认真学习了集团公司董事长张玉卓同志的讲话。&lt;/p&gt;\n\n&lt;p&gt;&amp;nbsp; &amp;nbsp; &amp;nbsp; &amp;nbsp;会后，党委书记李德芳对于学习贯彻会议精神，做好学院疫情防控和复工复产工作，做出了安排部署，要求各部门切实担负责任，抓好贯彻落实。一是要继续严格抓好疫情防控工作。目前学院疫情防控工作取得了阶段性成果，但是仍然不能放松、不能麻痹大意，要持续盯紧各项防控措施落实，持续做好来院上班人员健康状况把关、学院重点场所防控管理、防护物资采购供应等工作。二是抓紧举办各类网络培训班，推送更多的网络课程。结合北京地区疫情形势，提前谋划好下一步培训项目的实施办法。三是积极推进各项科研工作。鼓励居家办公教职工，充分利用好这段时间，加快科研课题的研究和课题报告撰写。四是按照年度目标任务和重点工作安排，有序推进HSSE、智慧学院建设、干部人才队伍建设、党建、纪检、群团等工作。五是抓好教职工理论学习和业务学习，统筹设计员工学习、党员学习计划和内容，努力提升教职工的政治理论素养和专业水平。六是领导干部要担当作为，发挥示范带头作用，在疫情防控和复工复产中，带头谋划、推动各项任务落实。七是加强好人好事的宣传，树立正确的舆论导向，弘扬积极向上的正能量。八是关心关爱职工，发挥党支部、群团组织作用，安排走访慰问、帮扶救助疫情期间遇到切实困难的职工，及时疏导职工焦虑情绪，保障身心健康。&lt;/p&gt;', NULL, 1, '2020-03-16 22:14:36', NULL, NULL);

-- ----------------------------
-- Table structure for sys_modules
-- ----------------------------
DROP TABLE IF EXISTS `sys_modules`;
CREATE TABLE `sys_modules`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `parentid` int(11) NULL DEFAULT NULL,
  `name` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin NULL DEFAULT NULL,
  `icon` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin NULL DEFAULT NULL,
  `modulepath` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin NULL DEFAULT NULL,
  `isshow` bit(1) NULL DEFAULT NULL,
  `levels` int(255) NULL DEFAULT NULL,
  `order` int(255) NULL DEFAULT NULL,
  `createuserid` int(11) NULL DEFAULT NULL,
  `createdate` datetime(0) NULL DEFAULT NULL,
  `updateuserid` int(11) NULL DEFAULT NULL,
  `updatedate` datetime(0) NULL DEFAULT NULL,
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 23 CHARACTER SET = utf8 COLLATE = utf8_bin ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of sys_modules
-- ----------------------------
INSERT INTO `sys_modules` VALUES (16, 1, '内容管理', 'fa fa-book', 'javascript:void(0)', b'1', 1, 0, 1, '2020-03-15 14:08:15', 1, '2020-03-15 14:08:15');
INSERT INTO `sys_modules` VALUES (17, 16, 'Banner管理', NULL, '/System/Banner/Index', b'1', 2, 0, 1, '2020-03-15 14:08:35', 1, '2020-03-15 14:08:35');
INSERT INTO `sys_modules` VALUES (18, 16, '新闻管理', NULL, '/System/News/Index', b'1', 2, 0, 1, '2020-03-15 14:08:50', 1, '2020-03-15 14:08:50');
INSERT INTO `sys_modules` VALUES (19, 1, '用户管理', 'fa fa-users', 'javascript:void(0)', b'1', 1, 0, 1, '2020-03-15 14:09:20', 1, '2020-03-15 14:09:20');
INSERT INTO `sys_modules` VALUES (20, 19, '客户管理', NULL, '/System/Customer/Index', b'1', 2, 0, 1, '2020-03-15 14:09:34', 1, '2020-03-15 14:09:34');
INSERT INTO `sys_modules` VALUES (21, 1, '系统管理', 'fa fa-cogs', 'javascript:void(0)', b'1', 1, 0, 0, '0001-01-01 00:00:00', 1, '2020-03-15 16:34:58');
INSERT INTO `sys_modules` VALUES (22, 21, '模块管理', NULL, '/System/Module/Index', b'1', 2, 0, 1, '2020-03-15 15:42:11', 1, '2020-03-15 15:42:11');

-- ----------------------------
-- Table structure for sys_rolemodules
-- ----------------------------
DROP TABLE IF EXISTS `sys_rolemodules`;
CREATE TABLE `sys_rolemodules`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `roleid` int(11) NULL DEFAULT NULL,
  `moduleid` int(11) NULL DEFAULT NULL,
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_bin ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for sys_roles
-- ----------------------------
DROP TABLE IF EXISTS `sys_roles`;
CREATE TABLE `sys_roles`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin NULL DEFAULT NULL,
  `description` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin NULL DEFAULT NULL,
  `createuserid` int(11) NULL DEFAULT NULL,
  `createdate` datetime(0) NULL DEFAULT NULL,
  `updateuserid` int(11) NULL DEFAULT NULL,
  `updatedate` datetime(0) NULL DEFAULT NULL,
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_bin ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for sys_users
-- ----------------------------
DROP TABLE IF EXISTS `sys_users`;
CREATE TABLE `sys_users`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin NULL DEFAULT NULL,
  `account` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin NULL DEFAULT NULL,
  `password` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin NULL DEFAULT NULL,
  `roleid` int(11) NULL DEFAULT NULL,
  `createuserid` int(11) NULL DEFAULT NULL,
  `createdate` datetime(0) NULL DEFAULT NULL,
  `updateuserid` int(11) NULL DEFAULT NULL,
  `updatedate` datetime(0) NULL DEFAULT NULL,
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 2 CHARACTER SET = utf8 COLLATE = utf8_bin ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of sys_users
-- ----------------------------
INSERT INTO `sys_users` VALUES (1, '超级管理员', 'admin', '21232f297a57a5a743894a0e4a801fc3', 1, 1, '2019-08-14 00:00:00', NULL, NULL);

SET FOREIGN_KEY_CHECKS = 1;
