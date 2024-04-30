<?php
/**
 * Plugin Name: WooSync
 * Description: A plugin to synchronize products from a desktop application to WooCommerce.
 * Version: 1.1.1
 * Author: CommerceSycn Team
 * Text Domain: woosync
 * Domain Path: /languages
 * License: GPL v2 or later
 * License URI: https://www.gnu.org/licenses/gpl-2.0.html
 */

// Kilépés közvetlen hozzáférés esetén.
if (!defined('ABSPATH')) exit;

require_once plugin_dir_path(__FILE__) . 'scripts/woosync-scripts.php';
require_once plugin_dir_path(__FILE__) . 'includes/woosync-class.php';

new WooSync();
?>