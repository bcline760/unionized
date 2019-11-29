USE `unionized`;

CREATE TABLE IF NOT EXISTS `user_token` (
    `id` INT AUTO_INCREMENT PRIMARY KEY,
    `slug` VARCHAR(32) NOT NULL,
    `token` VARCHAR(256) NOT NULL,
    `expiry` DATETIME NOT NULL,
    `generated_by` VARCHAR(32) NOT NULL,
    `created_at` DATETIME NOT NULL,
    `updated_at` DATETIME NULL,
    `active` INT(1),
    INDEX (`slug` , `token` , `generated_by`)
)