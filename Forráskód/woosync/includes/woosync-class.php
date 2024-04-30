<?php
class WooSync {
    function __construct() {
        add_action('admin_menu', array($this, 'ourMenu'));
        register_activation_hook(__FILE__, array($this, 'plugin_activation'));
        add_action('admin_init', array($this, 'register_settings'));
        add_action('admin_enqueue_scripts', array($this, 'enqueue_scripts'));
        add_action('wp_ajax_generate_api_key', array($this, 'generate_api_key_callback'));
        add_action('wp_ajax_reset_api_key', array($this, 'reset_api_key_callback'));
        add_action('admin_enqueue_scripts', array($this, 'enqueue_scripts'));

        // AJAX hívás a szinkronizációhoz és változások ellenőrzéséhez
        add_action('wp_ajax_sync_and_check_changes', array($this, 'sync_and_check_changes_callback'));
    }

    function ourMenu() {
        add_menu_page('WooSync', 'WooSync', 'manage_options', 'ourwoosyncplugin', array($this, 'woosyncSettingsPage'), 'dashicons-smiley', 111);
        add_submenu_page('ourwoosyncplugin', 'Infon', 'Information', 'manage_options', 'woosync-info', array($this, 'woosyncInfoPage'));
        add_submenu_page('ourwoosyncplugin', 'WooSync Authentication', 'Authentication', 'manage_options', 'woosync-authentication', array($this, 'woosyncAuthPage'));
        add_submenu_page('ourwoosyncplugin', 'WooSync Settings', 'Options', 'manage_options', 'woosync-settings', array($this, 'settingsSubPage'));
    }

    function plugin_activation() {
        global $wpdb;
        $charset_collate = $wpdb->get_charset_collate();
        $table_name = $wpdb->prefix . 'woosync_api_keys';
        $sql = "CREATE TABLE IF NOT EXISTS $table_name (
            id mediumint(9) NOT NULL AUTO_INCREMENT,
            api_key varchar(255) NOT NULL,
            PRIMARY KEY  (id)
        ) $charset_collate;";
        require_once(ABSPATH . 'wp-admin/includes/upgrade.php');
        dbDelta($sql);
    }

    function register_settings() {
        register_setting('woosync_settings', 'woosync_api_key');
        register_setting('woosync_settings', 'woosync_sync_interval');
        // Új beállítás a perces szinkronizációs időtartamhoz
        register_setting('woosync_settings', 'woosync_sync_interval_minutes');
    }

    function enqueue_scripts() {
        woosync_enqueue_scripts();
    }

    function woosyncSettingsPage() {
        include_once(plugin_dir_path(__FILE__) . '/../pages/woosync-info-page.php');
    }

    function woosyncInfoPage() {
        include_once(plugin_dir_path(__FILE__) . '/../pages/woosync-info-page.php');
    }

    function settingsSubPage() {
        include_once(plugin_dir_path(__FILE__) . '/../pages/woosync-settings-page.php');
    }

    function woosyncAuthPage() {
        include_once(plugin_dir_path(__FILE__) . '/../pages/woosync-authentication.php');
    }

    function generate_api_key_callback() {
        global $wpdb;
        $table_name = $wpdb->prefix . 'woosync_api_keys';

        // Ellenőrizzük, hogy van-e már mentett API kulcs
        $existing_key = $wpdb->get_var("SELECT api_key FROM $table_name");

        if (!$existing_key) {
            // Ha nincs tárolt kulcs, akkor generáljunk egy újat
            $api_key = wp_generate_password(32, false);

            // Mentsük el az új API kulcsot az adatbázisba
            $wpdb->insert(
                $table_name,
                array(
                    'api_key' => $api_key
                )
            );
        } else {
            // Ha már van tárolt kulcs, használjuk azt
            $api_key = $existing_key;
        }

        // Return the generated API key
        echo '<div class="wrap">
            <p>Your API Key: ' . esc_html($api_key) . '</p> 
            <button class="copy-api-key-btn" data-api-key="' . esc_attr($api_key) . '">Copy API Key</button>
            <form method="post" action="">
                <input type="hidden" name="woosync_reset_key" value="1">
                <button type="submit" class="reset-api-key-btn">Reset API Key</button>
            </form>
        </div>';

        // It's important to exit after echoing the response
        wp_die();
    }

    function reset_api_key_callback() {
        global $wpdb;
        $table_name = $wpdb->prefix . 'woosync_api_keys';

        // Töröljük az összes rekordot az adatbázistáblából
        $wpdb->query("DELETE FROM $table_name");

        echo '<div class="wrap">
            <p>API Key reset successfully.</p>
            <button id="generate-api-key-btn">Generate API Key</button>
        </div>';

        wp_die();
    }

    // Szinkronizáció és változások ellenőrzése
    function sync_and_check_changes_callback() {
        include_once(plugin_dir_path(__FILE__) . 'includes/woosync-sync.php');

        // Szinkronizáció és változások ellenőrzése
        $result = syncAndCheckChanges();

        // AJAX válasz küldése a kliensnek
        wp_send_json_success($result);
    }
}
?>
