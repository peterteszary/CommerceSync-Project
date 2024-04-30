//db property check, clicking icon  will be visible and clicking again to invisible
import { ref } from 'vue';
import { mount } from '@vue/test-utils';


describe('mariadbproperty', () => {
  it('visibility of property', () => {
    const property = ref(false);
    const wrapper = mount({
      setup() {
        return { property };
      },
      template: `<div @click="mariadbproperty">{{ property }}</div>`, 
    });

    expect(wrapper.text()).toContain('false');

    wrapper.trigger('click');

   
  });
});
