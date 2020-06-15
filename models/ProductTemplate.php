<?php

namespace app\models;

use Yii;

class ProductTemplate extends \yii\db\ActiveRecord
{
    public static function tableName()
    {
        return 'product_template';
    }

    public function rules()
    {
        return [
            [['message_main_attachment_id', 'sequence', 'rental', 'categ_id', 'list_price', 'volume', 'weight', 'sale_ok', 'purchase_ok', 'uom_id', 'uom_po_id', 'company_id', 'color', 'can_image_1024_be_zoomed', 'has_configurable_attributes', 'create_uid', 'write_uid', 'website_id', 'website_size_x', 'website_size_y', 'website_sequence'], 'integer'],
            [['name', 'description', 'description_purchase', 'description_sale', 'type', 'company_name', 'categ_name',  'default_code', 'tracking', 'description_picking', 'description_pickingout', 'description_pickingin', 'service_type', 'sale_line_warn', 'sale_line_warn_msg', 'expense_policy', 'invoice_policy', 'website_meta_title', 'website_meta_description', 'website_meta_keywords', 'website_meta_og_img', 'website_description', 'inventory_availability', 'custom_message', 'purchase_method', 'purchase_line_warn', 'purchase_line_warn_msg', 'active'], 'string'],
           // [['name'], 'required'],
            [['sale_delay', 'produce_delay', 'is_published', 'rating_last_value', 'available_threshold', 'service_to_purchase'], 'number'],
            [['create_date', 'write_date'], 'safe'],

            [['create_uid'], 'exist', 'skipOnError' => true, 'targetClass' => ResUsers::className(), 'targetAttribute' => ['create_uid' => 'id']],            
            [['message_main_attachment_id'], 'exist', 'skipOnError' => true, 'targetClass' => IrAttachment::className(), 'targetAttribute' => ['message_main_attachment_id' => 'id']],
            [['write_uid'], 'exist', 'skipOnError' => true, 'targetClass' => ResUsers::className(), 'targetAttribute' => ['write_uid' => 'id']],
        ];
    }

    public function attributeLabels()
    {
        return [
            'id' => 'ID',
            'message_main_attachment_id' => 'Message Main Attachment ID',
            'name' => 'Nombre',
            'sequence' => 'Sequence',
            'description ' => 'Descripcion',
            'description_purchase' => 'Description_purchase ',
            'description_sale' => 'Descripcion de Venta',
            'type' => 'Tipo',
            'rental' => 'rental',
            'categ_id' => 'Categoria',
            'categ_name' => 'Categoria',
            'list_price' => 'Precio',
            'volume ' => 'volume',
            'weight ' => 'weight',
            'sale_ok' => 'sale_ok',
            'purchase_ok' => 'purchase_ok',
            'uom_id' => 'uom_id',
            'uom_po_id' => 'uom_po_id',
            'company_id' => 'Compañia',
            'company_name' => 'Compañia',
            'active' => 'Estatus',
            'color' => 'Color',
            'default_code' => 'default_code',
            'can_image_1024_be_zoomed' => 'can_image_1024_be_zoomed',
            'has_configurable_attributes' => 'has_configurable_attributes',
            'create_uid' => 'create_uid',
            'create_date' => 'Fecha de Creación',
            'write_uid' => 'write_uid',
            'write_date' => 'write_date',
            'sale_delay' => 'sale_delay',
            'tracking' => 'tracking',
            'description_picking' => 'description_picking',
            'description_pickingout' => 'description_pickingout',
            'description_pickingin' => 'description_pickingin',
            'produce_delay' => 'produce_delay',
            'service_type' => 'service_type',
            'sale_line_warn' => 'sale_line_warn',
            'sale_line_warn_msg' => 'sale_line_warn_msg',
            'expense_policy' => 'expense_policy',
            'invoice_policy' => 'invoice_policy',
            'website_meta_title' => 'website_meta_title',
            'website_meta_description' => 'website_meta_description',
            'website_meta_keywords' => 'website_meta_keywords',
            'website_meta_og_img' => 'website_meta_og_img',
            'website_id' => 'website_id',
            'is_published' => 'is_published',
            'rating_last_value' => 'rating_last_value',
            'website_description' => 'website_description',
            'website_size_x' => 'website_size_x',
            'website_size_y' => 'website_size_y',
            'website_sequence' => 'website_sequence',
            'inventory_availability' => 'inventory_availability',
            'available_threshold' => 'available_threshold',
            'custom_message' => 'custom_message',
            'purchase_method' => 'purchase_method',
            'purchase_line_warn' => 'purchase_line_warn',
            'purchase_line_warn_msg' => 'purchase_line_warn_msg',
            'service_to_purchase' => 'service_to_purchase',
        ];
    }

    

    public function getCompany()
    {
        return $this->hasOne(ResCompany::className(), ['name' => 'company_name']);
    }

     public function getProductCategory()
    {
        return $this->hasOne(ProductCategory::className(), ['name' => 'categ_name']);
    }


    

    public static function find()
    {
        return new ProductTemplateQuery(get_called_class());
    }
}
