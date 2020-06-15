<?php

namespace app\models;

use yii\base\Model;
use yii\data\ActiveDataProvider;
use app\models\ProductTemplate;

class ProductTemplateSearch extends ProductTemplate
{
    public function rules()
    {
        return [
            [['message_main_attachment_id', 'sequence', 'rental', 'categ_id', 'list_price', 'volume', 'weight', 'sale_ok', 'purchase_ok', 'uom_id', 'uom_po_id', 'company_id', 'color', 'can_image_1024_be_zoomed', 'has_configurable_attributes', 'create_uid', 'write_uid', 'website_id', 'website_size_x', 'website_size_y', 'website_sequence'], 'integer'],
            [['name', 'description', 'description_purchase', 'description_sale', 'type', 'company_name', 'default_code', 'tracking', 'description_picking', 'description_pickingout', 'description_pickingin', 'service_type', 'sale_line_warn', 'sale_line_warn_msg', 'expense_policy', 'invoice_policy', 'website_meta_title', 'website_meta_description', 'website_meta_keywords', 'website_meta_og_img', 'website_description', 'inventory_availability', 'custom_message', 'purchase_method', 'purchase_line_warn', 'purchase_line_warn_msg',  'active'], 'string'],
           // [['name'], 'required'],
            [['sale_delay', 'produce_delay', 'is_published', 'rating_last_value', 'available_threshold', 'service_to_purchase'], 'number'],
        ];
    }

    public function scenarios()
    {
        return Model::scenarios();
    }

    public function search($params)
    {
        $query = ProductTemplate::find();


        $dataProvider = new ActiveDataProvider([
            'query' => $query,
        ]);

        $this->load($params);

        if (!$this->validate()) {
            return $dataProvider;
        }

        $query->andFilterWhere([
            'id' => $this->id,
            'message_main_attachment_id' => $this->message_main_attachment_id,
            'name' => $this->name,
            'sequence' => $this->sequence,
            'description' => $this->description,
            'description_purchase' => $this->description_purchase,
            'description_sale' => $this->description_sale,
            'type' => $this->type,
            'rental' => $this->rental,
            'categ_id' => $this->categ_id,
            'categ_name' => $this->categ_name,
            'list_price' => $this->list_price,
            'volume' => $this->volume,
            'weight' => $this->weight,
            'sale_ok' => $this->sale_ok,
            'purchase_ok' => $this->purchase_ok,
            'uom_id' => $this->uom_id,
            'uom_po_id' => $this->uom_po_id,
            'company_id' => $this->company_id,
            'company_name' => $this->company_name,
            'active' => $this->active,
            'color' => $this->color,
            'default_code' => $this->default_code,
            'can_image_1024_be_zoomed' => $this->can_image_1024_be_zoomed,
            'has_configurable_attributes' => $this->has_configurable_attributes,
            'create_uid' => $this->create_uid,
            'create_date' => $this->create_date,
            'write_uid' => $this->write_uid,
            'write_date' => $this->write_date,
            'sale_delay' => $this->sale_delay,
            'tracking' => $this->tracking,
            'description_picking' => $this->description_picking,
            'description_pickingout' => $this->description_pickingout,
            'description_pickingin' => $this->description_pickingin,
            'produce_delay' => $this->produce_delay,
            'service_type' => $this->service_type,
            'sale_line_warn' => $this->sale_line_warn,
            'sale_line_warn_msg' => $this->sale_line_warn_msg,            
            'expense_policy' => $this->expense_policy,
            'invoice_policy' => $this->invoice_policy,
            'website_meta_title' => $this->website_meta_title,
            'website_meta_description' => $this->website_meta_description,
            'website_meta_keywords' => $this->website_meta_keywords,
            'website_meta_og_img' => $this->website_meta_og_img,
            'website_id' => $this->website_id,            
            'is_published' => $this->is_published,
            'rating_last_value' => $this->rating_last_value,
            'website_description' => $this->website_description,
            'website_size_x' => $this->website_size_x,
            'website_size_y' => $this->website_size_y,
            'website_sequence' => $this->website_sequence,
            'inventory_availability' => $this->inventory_availability,
            'available_threshold' => $this->available_threshold,
            'custom_message' => $this->custom_message,
            'purchase_method' => $this->purchase_method,
            'purchase_line_warn' => $this->purchase_line_warn,
            'purchase_line_warn_msg' => $this->purchase_line_warn_msg,
            'purchase_line_warn_msg' => $this->purchase_line_warn_msg,
            'service_to_purchase' => $this->service_to_purchase,
            


        ]);

        $query->andFilterWhere(['like', 'name', $this->name])
            ->andFilterWhere(['like', 'sequence', $this->sequence])
            ->andFilterWhere(['like', 'description', $this->description])
            ->andFilterWhere(['like', 'description_purchase', $this->description_purchase]);

        return $dataProvider;
    }
}
