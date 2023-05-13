/** @type {import('tailwindcss').Config} */
module.exports = {
  content: [
    './pages/**/*.{js,ts,jsx,tsx,mdx}',
    './components/**/*.{js,ts,jsx,tsx,mdx}',
    './app/**/*.{js,ts,jsx,tsx,mdx}',
    "./node_modules/flowbite-react/**/*.js"
  ],
  theme: {
    extend: {
      backgroundImage: {    
        'gradient-radial': 'radial-gradient(var(--tw-gradient-stops))',
        'gradient-conic':
          'conic-gradient(from 180deg at 50% 50%, var(--tw-gradient-stops))',
      },
      colors: {
        primary: '#EF8236',
        primarylight: '#F2A355',
        primarydark:'#BC662A',
        secondary: '#6B7280',
        secondarylight: '#F3F4F6',
        secondarydark: '#555555'
      }
    },
  },
  plugins: [
    require("flowbite/plugin")
  ],
}
