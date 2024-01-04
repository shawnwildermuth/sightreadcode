/** @type {import('tailwindcss').Config} */
module.exports = {
  content: [
    "src/**/*.{js,ts,html,vue}"
  ],
  theme: {
    extend: {},
  },
  plugins: [require("daisyui")],
  daisyui: {
    themes: ["business"],
  },
}

