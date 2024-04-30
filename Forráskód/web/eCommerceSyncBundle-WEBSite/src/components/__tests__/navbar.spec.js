//check mobile screen in hamburger menu to be correct working
import { shallowMount } from '@vue/test-utils';
import Navbar from '../AppNavbar.vue'; 

describe('Navbar', () => {
  it('toggles hamburger menu on click', async () => {
    const wrapper = shallowMount(Navbar);
    
    expect(wrapper.vm.hamburgerMenu).toBe(false);


    await wrapper.find('.text-black').trigger('click');

    expect(wrapper.vm.hamburgerMenu).toBe(true);
  });
});
