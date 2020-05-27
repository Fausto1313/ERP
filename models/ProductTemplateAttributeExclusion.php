<?php

namespace app\models;

use Yii;

class ProductTemplateAttributeExclusion extends \yii\db\ActiveRecord
{
    public static function tableName()
    {
        return 'product_template_attribute_exclusion';
    }

    public function rules()
    {
        return [
            [['product_template_attribute_value_id', 'product_tmpl_id', 'create_uid', 'write_uid'], 'integer'],
            [['product_tmpl_id'], 'required'],
            [['create_date', 'write_date'], 'safe'],
            [['trial395'], 'string', 'max' => 1],
            [['product_template_attribute_value_id'], 'exist', 'skipOnError' => true, 'targetClass' => ProductTemplateAttributeValue::className(), 'targetAttribute' => ['product_template_attribute_value_id' => 'id']],
            [['create_uid'], 'exist', 'skipOnError' => true, 'targetClass' => ResUsers::className(), 'targetAttribute' => ['create_uid' => 'id']],
            [['write_uid'], 'exist', 'skipOnError' => true, 'targetClass' => ResUsers::className(), 'targetAttribute' => ['write_uid' => 'id']],
        ];
    }

    public function attributeLabels()
    {
        return [
            'id' => 'ID',
            'product_template_attribute_value_id' => 'Product Template Attribute Value ID',
            'product_tmpl_id' => 'Product Tmpl ID',
            'create_uid' => 'Create Uid',
            'create_date' => 'Create Date',
            'write_uid' => 'Write Uid',
            'write_date' => 'Write Date',
            'trial395' => 'Trial395',
        ];
    }

    public function getProductTemplateAttributeValue()
    {
        return $this->hasOne(ProductTemplateAttributeValue::className(), ['id' => 'product_template_attribute_value_id']);
    }

    public function getCreateU()
    {
        return $this->hasOne(ResUsers::className(), ['id' => 'create_uid']);
    }

    public function getWriteU()
    {
        return $this->hasOne(ResUsers::className(), ['id' => 'write_uid']);
    }

    public static function find()
    {
        return new ProductTemplateAttributeExclusionQuery(get_called_class());
    }
}
