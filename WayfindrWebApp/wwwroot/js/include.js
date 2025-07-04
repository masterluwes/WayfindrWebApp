document.addEventListener("DOMContentLoaded", function () {
  const includes = document.querySelectorAll("[data-include]");
  includes.forEach(async el => {
    const file = el.getAttribute("data-include");
    const res = await fetch(file);
    if (res.ok) {
      el.innerHTML = await res.text();
    } else {
      el.innerHTML = "Could not load component.";
    }
  });

  // ✅ Dynamic active nav tab glow based on current page
  const currentPage = window.location.pathname.split("/").pop() || "index.html";
  const observer = new MutationObserver(() => {
    const links = document.querySelectorAll(".nav-link");
    links.forEach(link => {
      const linkPage = link.getAttribute("href");
      if (linkPage === currentPage) {
        link.classList.add("active");
      } else {
        link.classList.remove("active");
      }
    });
  });

  // Observe for added DOM content (like from includes)
  observer.observe(document.body, {
    childList: true,
    subtree: true,
  });
});
