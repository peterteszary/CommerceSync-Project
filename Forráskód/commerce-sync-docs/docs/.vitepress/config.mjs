import { defineConfig } from 'vitepress'

// https://vitepress.dev/reference/site-config
export default defineConfig({
  base: '/commerce-sync-docs/',
  title: "Commerce Sync Docs",
  description: "A Projektünk dokumentációs oldala",
  themeConfig: {

    logo: 'commercesynclogo.png',

    // https://vitepress.dev/reference/default-theme-config
    nav: [
      { text: 'Kezdőlap', link: '/' },
      { text: 'Dokumentáció', link: '/a-projektrol' }
    ],

    sidebar: [
      {
        text: 'A Projekt dokumentációja',
        items: [
          { text: 'A Projektről', link: '/a-projektrol' },
          { text: 'A fejlesztői csapat', link: '/fejlesztok' },
          { text: 'Komponensek', link: '/komponensek' },
          { text: 'Desktop Applikáció', link: '/desktop' },
          { text: 'WordPress Bővítmény', link: '/plugin' },
          { text: 'Dokumentáció', link: '/dokumentacio' },
          { text: 'Installás', link: '/installalas' }
        ]
        
      },
      {
        text: 'Fejlesztői naplók',
        items: [
          { text: 'Fejlesztői napló', link: 'fejlesztoi-naplok/fejlesztoi-naplo' },
        ]
        
      },
      {
        text: 'Tesztelési naplók',
        items: [
          { text: 'Tesztelési napló', link: 'tesztelesi-naplok/tesztelesi-naplo' },
        ]
        
      },
      {
        text: 'A csomag jövője',
        items: [
          { text: 'Fejlesztési lehetőségek', link: 'jovo' },
        
        ]
        
      },
      {
        text: 'Letöltések',
        items: [
          { text: 'ProductBridge', link: 'https://github.com/2023e-vp-vizsgaremek/e-commerce/tree/master/Forr%C3%A1sk%C3%B3d/ProductBridge' },
          { text: 'WooSync', link: 'https://github.com/CommerceSync-Hub/WooSync' },
          { text: 'CommerceSync Theme', link: 'https://github.com/CommerceSync-Hub/eCommerce-Sync-Theme' },
          { text: 'Vizsgaremek Repo', link: 'https://github.com/2023e-vp-vizsgaremek/e-commerce/' },
        ]
        
      }
      
    ],

    socialLinks: [
      { icon: 'github', link: 'https://github.com/2023e-vp-vizsgaremek/e-commerce/' }
    ]
  }
})
