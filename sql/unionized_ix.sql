USE `unionized`;
CREATE INDEX `IX_NETWORKLOG_SLUG` ON `unionized`.`network_log`(`slug`);
CREATE INDEX `IX_NETWORKLOG_LOGDATE` ON `unionized`.`network_log`(`log_date`);
CREATE INDEX `IX_NETWORKLOG_SRCADDR` ON `unionized`.`network_log`(`src_address`);
CREATE INDEX `IX_NETWORKLOG_DSTADDR` ON `unionized`.`network_log`(`dst_address`);
CREATE INDEX `IX_NETWORKLOG_SRCPORT` ON `unionized`.`network_log`(`src_port`);
CREATE INDEX `IX_NETWORKLOG_DSTPORT` ON `unionized`.`network_log`(`dst_port`);
CREATE INDEX `IX_NETWORKLOG_CREATEDAT` ON `unionized`.`network_log`(`created_at`);