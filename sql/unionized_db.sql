CREATE DATABASE IF NOT EXISTS `unionized`;
CREATE TABLE IF NOT EXISTS `unionized`.`network_log` (
    `id` INT AUTO_INCREMENT PRIMARY KEY,
    `slug` VARCHAR(32) NOT NULL,
    `log_date` DATETIME NOT NULL,
    `rule` VARCHAR(16) NOT NULL,
    `iface_in` VARCHAR(8) NOT NULL,
    `iface_out` VARCHAR(8) NOT NULL,
    `mac_address` VARCHAR(32) NOT NULL,
    `src_address` VARCHAR(24) NOT NULL,
    `dst_address` VARCHAR(24) NOT NULL,
    `packet_len` INT NOT NULL,
    `ttl` INT NOT NULL,
    `protocol` VARCHAR(8) NOT NULL,
    `src_port` INT NULL,
    `dst_port` INT NULL,
    `tcp_action` VARCHAR(16) NULL,
    `icmp_sequence` INT NULL,
    `created_at` DATETIME NOT NULL,
    `updated_at` DATETIME NULL,
    `active` INT(1)
);

CREATE TABLE IF NOT EXISTS `unionized`.`user_token` (
    `id` INT AUTO_INCREMENT PRIMARY KEY,
    `slug` VARCHAR(32) NOT NULL,
    `token` VARCHAR(256) NOT NULL,
    `expiry` DATETIME NOT NULL,
    `generated_by` VARCHAR(32) NOT NULL,
    `created_at` DATETIME NOT NULL,
    `updated_at` DATETIME NULL,
    `active` INT(1),
    INDEX (`slug` , `token` , `generated_by`)
);

CREATE TABLE IF NOT EXISTS `unionized`.`role` (
    `id` INT AUTO_INCREMENT PRIMARY KEY,
    `ad_group` VARCHAR(32) NOT NULL,
    `role` VARCHAR(32) NOT NULL
);