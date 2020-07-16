--用户信息表
CREATE TABLE sys_userinfo(
    i_id INT NOT NULL AUTO_INCREMENT  COMMENT 'id' ,
    c_login_name VARCHAR(32) NOT NULL   COMMENT '登录名' ,
    c_password VARCHAR(32) NOT NULL   COMMENT '密码' ,
    i_lock VARCHAR(1)   DEFAULT 0 COMMENT '是否锁定 0正常1锁定' ,
    d_create_time DATETIME NOT NULL   COMMENT '创建时间' ,
    d_update_time DATETIME    COMMENT '更新时间' ,
    PRIMARY KEY (i_id)
) COMMENT = '用户信息 ';;